using Microsoft.EntityFrameworkCore;
using PortalDePedidosServidor.Models;
using PortalDePedidosShared.LoginVM;

namespace PortalDePedidosServidor.Servicios
{
    public class BloqueoLogInService
    {
        private static readonly List<SolicitudLogInVM> _solicitudes = new();
        private PortalTestContext _context;
        private IConfiguration _configuration;
        private int _limiteIntentos;
        private int _tiempoBloqueo;

        public BloqueoLogInService(PortalTestContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _limiteIntentos = int.Parse(_configuration.GetConnectionString("LimiteIntentosLogIn"));
            _tiempoBloqueo = int.Parse(_configuration.GetConnectionString("TiempoBloqueoLogIn"));
        }

        public async Task AddSolicitud(string nombreUsuairo, string Ip)
        {
            //verifico si el usuario existe
            Usuario? usuario = await _context.Usuarios.Where(x => x.NombreUsuario == nombreUsuairo).FirstOrDefaultAsync();

            if (usuario != null)
            {
                if (_solicitudes.Any(x => x.nombreUsuario == nombreUsuairo && x.Ip == Ip))
                {
                    //si la solicitud existe sumo el conteo y actualizo fecha
                    var solicitudExistente = _solicitudes.FirstOrDefault(x => x.nombreUsuario == nombreUsuairo && x.Ip == Ip);
                    solicitudExistente.FechaUltimaSolicitud = DateTime.Now;
                    solicitudExistente.Conteo++;
                }
                else
                {
                    //sino la creo
                    SolicitudLogInVM solicitud = new();
                    solicitud.IdUsuario = usuario.IdUsuario;
                    solicitud.nombreUsuario = nombreUsuairo;
                    solicitud.Ip = Ip;
                    solicitud.FechaUltimaSolicitud = DateTime.Now;
                    solicitud.Conteo++;
                    _solicitudes.Add(solicitud);
                }
            }
        }

        public bool SuperaLimiteDeIntentos(string nombreUsuario, string ip)
        {
            var solicitud = _solicitudes.SingleOrDefault(x => x.nombreUsuario == nombreUsuario && x.Ip == ip);
            if (solicitud != null)
            {
                return solicitud.Conteo >= _limiteIntentos;
            }

            return false;
        }

        public void BloqueoLogIn(string nombreUsuario, string ip)
        {
            var solicitud = _solicitudes.SingleOrDefault(x => x.nombreUsuario == nombreUsuario && x.Ip == ip);
            if (solicitud != null)
            {
                solicitud.Bloqueado = true;
            }
        }

        public bool IsLogInBloqueado(string nombreUsuario, string ip)
        {
            var solicitud = _solicitudes.SingleOrDefault(x => x.nombreUsuario == nombreUsuario && x.Ip == ip);
            if (solicitud != null && solicitud.Bloqueado)
            {
                var ahora = DateTime.Now;
                var vencimiento = solicitud.FechaUltimaSolicitud.AddMinutes(_tiempoBloqueo);
                
                if(ahora >= vencimiento)
                {
                    //si el usuario esta bloqueado y ya se cumplio el tiempo lo quito de la lista y lo dejo loguearse
                    _solicitudes.Remove(solicitud);
                    return false;
                }
                else
                {
                    //si sigue bloqueado no lo dejo loguearse
                    return true;
                }
            }

            return false;
        }
        public void EliminarSolicitud(string nombreUsuario, string ip)
        {
            var solicitud = _solicitudes.SingleOrDefault(x => x.nombreUsuario == nombreUsuario && x.Ip == ip);
            if (solicitud != null)
            {
                _solicitudes.Remove(solicitud);
            }
        }

    }
}
