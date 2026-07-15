using DocumentFormat.OpenXml.Drawing;
using PortalDePedidosModel;
using PortalDePedidosShared.LoginVM;

namespace PortalDePedidosServidor.Servicios
{
    public class LogInMFAService
    {
        private static readonly List<LogInMFAVM> _sesionesAprobadas = new List<LogInMFAVM>();
        private MailService _mailService { get; set; }

        public LogInMFAService(MailService mailService) 
        {
            //_sesionesAprobadas = new List<LogInMFAVM>();
            _mailService = mailService;
        }

        private LogInMFAVM GenerarLoginMFA(SesionUsuario sesion)
        {
            var codigo = GenerarNumeroUnico();

            var sesionMFA = new LogInMFAVM();
            sesionMFA.Codigo = codigo;
            sesionMFA.SesionUsuario = sesion;

            return sesionMFA;
        }

        private int GenerarNumeroUnico()
        {
            Random rnd = new Random();
            int numero;

            do
            {
                numero = rnd.Next(10000, 100000); // Genera un número entre 10000 y 99999
            }
            while (_sesionesAprobadas.Any(x=> x.Codigo == numero));

            return numero;
        }

        private void EliminarLoginMFA(int codigo)
        {
            var sesionMFA = _sesionesAprobadas.SingleOrDefault(x=> x.Codigo == codigo);
            if(sesionMFA != null)
                _sesionesAprobadas.Remove(sesionMFA);
        }

        public async Task IniciarLogInMFA(SesionUsuario sesion)
        {
            var sesionMFA = GenerarLoginMFA(sesion);
            _sesionesAprobadas.Add(sesionMFA);
            await _mailService.EnviarMailLogInMFA(sesionMFA);
        }

        public SesionUsuario ObtenerSesion(int codigo)
        {
            var sesion = _sesionesAprobadas.SingleOrDefault(x => x.Codigo == codigo).SesionUsuario;
            EliminarLoginMFA(codigo);
            return sesion;
        }
    }
}
