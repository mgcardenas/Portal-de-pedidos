using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PortalDePedidosServidor.Models;
using PortalDePedidosShared.LoginVM;
using Microsoft.EntityFrameworkCore;
using PortalDePedidosModel;
using PortalDePedidosShared.CuentasCorrientesVM;

namespace PortalDePedidosServidor
{
    public class MailService
    {
        #region Private Variables

        private const string _emailRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        private Regex _regex;
        private int _reintentos = 0;
        private PortalTestContext _context;
        private IConfiguration _configuration;
        private bool _flagTest;
        private string _contactoCtaCte = "";

        #endregion

        #region Constructors

        public MailService(PortalTestContext context, IConfiguration configuration)
        {
            _regex = new Regex(_emailRegex);
            this._context = context;
            _configuration = configuration;
            _flagTest = bool.Parse(_configuration.GetConnectionString("AppTest"));
            _contactoCtaCte = _configuration.GetConnectionString("ContactoCtaCte");
        }

        #endregion


        private async Task FormatearEnviarMailConsultaSaldo(Usuario cliente , string mensaje)
        {
            var msj = $"<p>" +
                $"<b>Atención</b>: <br />" +
                $"El usuario {cliente.NombreUsuario} ha solicitado hoy <b>{DateTime.Now.ToString("dd/MM/yyyy  H:mm:ss")}</b> una consulta con el siguiente mensaje:<br />" +
                $"{mensaje}. <br />" +
                //$"está consultando acerca de su Saldo a Favor no Aplicado con importe ${saldo.ToString("N2", new System.Globalization.CultureInfo("es-AR"))}. <br />" +
                $"Por favor responder a su mail de contacto: {cliente.MailUsuario}." +
            $"</p>";


            await EnviarMailAsync(_contactoCtaCte, "Consulta de Saldo a Favor", msj);

        }
        private async Task FormatearEnviarMailRecuperar(OlvideContrasenaVM recuperar,string destinatario)
        {
            var msj = $"<p>" +
                $"<b>Atención, {recuperar.nombreUsuario}</b>: <br />" +
                $"Usted ha solicitado hoy <b>{DateTime.Now.ToString("dd/MM/yyyy  H:mm:ss")}</b> el cambio de contraseña. <br />" +
                $"Haga click  <a href=\"{recuperar.path + "RecuperarContrasena/" + recuperar.id}\">aqu&iacute;</a> para cambiar su contraseña.<br />" +
                $"Si no ha sido usted ignore este mail." +
            $"</p>";


            await EnviarMailAsync(destinatario, "Cambio de Contraseña", msj);

        }

        private async Task FormatearMailLogInMFA(LogInMFAVM logInMFA)
        {
            var msj = $"<p>" +
                $"<b>Atención, {logInMFA.SesionUsuario.NombreUsuario}</b>: <br />" +
                $"Usted ha solicitado hoy <b>{DateTime.Now.ToString("dd/MM/yyyy  H:mm:ss")}</b> el inicio de sesión. <br />" +
                $"Su código se seguridad es <b>{logInMFA.Codigo}</b>. <br />" +
                $"Si no ha sido usted ignore este mail." +
            $"</p>";


            await EnviarMailAsync(logInMFA.SesionUsuario.Correo, "Inicio de sesión", msj);

        }

        private async Task EnviarMailAsync(string to, string subject, string body)
        {
            #region Send Grid

            //try
            //{
                var fromEmail = _configuration.GetConnectionString("SMTPUser");
                var fromDisplayName = "";
                if (_flagTest)
                {
                    fromDisplayName = "PCR[Test]";
                }
                else
                {
                    fromDisplayName = "PCR";
                }

                var smtpPass = _configuration.GetConnectionString("SMTPPassword");

                //Email 
                MailMessage myMessage = new MailMessage();

                myMessage.BodyEncoding = Encoding.UTF8;
                myMessage.SubjectEncoding = Encoding.UTF8;
                myMessage.HeadersEncoding = Encoding.UTF8;
                myMessage.To.Add(to);
                myMessage.From = new MailAddress(fromEmail, fromDisplayName);
                myMessage.Subject = subject;
                myMessage.Body = body;
                myMessage.IsBodyHtml = true;
                //cc.ForEach(x => myMessage.CC.Add(x));

                //create Alrternative HTML view
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");

                //Add view to the Email Message
                myMessage.AlternateViews.Add(htmlView);

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.EnableSsl = bool.Parse(_configuration.GetConnectionString("EnableSsl"));
                    smtp.Host = _configuration.GetConnectionString("SMTPServer");
                    smtp.Port = int.Parse(_configuration.GetConnectionString("SMTPServerPort"));
                    smtp.UseDefaultCredentials = false;
                    //Si la contraseña está vacía, el mail se envía si autenticarse en el servidor smtp
                    if (smtpPass != "")
                        smtp.Credentials = new NetworkCredential(fromEmail, smtpPass);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.SendCompleted += (s, e) => { smtp.Dispose(); };
                    await smtp.SendMailAsync(myMessage);
                }

            //}
            //catch (Exception ex)
            //{
            //    if (_reintentos-- > 0)
            //    {
            //       await EnviarMailAsync(to, subject, body);
            //    }
            //}

            #endregion
        }
        public async Task<bool> EnviarMailConsulta(ConsultaSaldoAFavor consulta)
        {
            Usuario? usuario = await _context.Usuarios.Where(x => x.IdUsuario == consulta.IdCliente).FirstOrDefaultAsync();

            if (usuario != null)
            {
                await FormatearEnviarMailConsultaSaldo(usuario,consulta.Mensaje);
                return true;
            }
            return false;
        }
        public async Task<bool> EnviarMailRecuperar(OlvideContrasenaVM recuperar)
        {
            Usuario? usuario = await _context.Usuarios.Where(x => x.NombreUsuario == recuperar.nombreUsuario).FirstOrDefaultAsync();

            if (usuario != null) 
            {
                recuperar.id = usuario.IdUsuario;
                await FormatearEnviarMailRecuperar(recuperar,usuario.MailUsuario);
                return true;
            }
            return false;
        }

        public async Task EnviarMailLogInMFA(LogInMFAVM logInMFA)
        {
            await FormatearMailLogInMFA(logInMFA);
        }
    }
}
