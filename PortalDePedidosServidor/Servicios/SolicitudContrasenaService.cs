using Microsoft.EntityFrameworkCore;
using PortalDePedidosServidor.Models;
using PortalDePedidosShared.LoginVM;
namespace PortalDePedidosServidor.Servicios
{
    public class SolicitudContrasenaService
    {
        private static readonly List<SolicitudContrasenaVM> _solicitudes = new();
        private PortalTestContext _context;

        public SolicitudContrasenaService(PortalTestContext context)
        {
            _context = context;
        }

        public async Task AddSolicitud(string nombreUsuairo,string Ip )
        {
            //verifico si el usuario existe
            Usuario? usuario = await _context.Usuarios.Where(x => x.NombreUsuario == nombreUsuairo).FirstOrDefaultAsync();

            if (usuario != null)
            {
                if(_solicitudes.Any(x=> x.nombreUsuario == nombreUsuairo && x.Ip == Ip))
                {
                    //si la solicitud existe sumo el conteo y actualizo fecha
                    var solicitudExistente = _solicitudes.FirstOrDefault(x => x.nombreUsuario == nombreUsuairo);
                    solicitudExistente.FechaUltimaSolicitud = DateTime.Now;
                    solicitudExistente.Conteo++;
                }
                else
                {
                    //sino la creo
                    SolicitudContrasenaVM solicitud = new();
                    solicitud.IdUsuario = usuario.IdUsuario;
                    solicitud.nombreUsuario = nombreUsuairo;
                    solicitud.Ip = Ip;
                    solicitud.FechaUltimaSolicitud = DateTime.Now;
                    solicitud.Conteo++;
                    _solicitudes.Add(solicitud);
                }
            }
        }

        public int GetNroSolicitudes(string nombreUsuario, string ip)
        {
            var solicitud = _solicitudes.SingleOrDefault(x => x.nombreUsuario == nombreUsuario && x.Ip == ip);
            if (solicitud != null)
            {
                return solicitud.Conteo;
            }

            return 0;
        }

        public bool SolicitudVigente(int idUsuario)
        {
            var solicitud = _solicitudes.Where(x=> x.IdUsuario == idUsuario).OrderByDescending(x=> x.FechaUltimaSolicitud).FirstOrDefault();
            if (solicitud != null)
            {
                var ahora = DateTime.Now;
                var vencimiento = solicitud.FechaUltimaSolicitud.AddMinutes(15);

                return ahora <= vencimiento;
            }

            return false;
        }

        public void EliminarSolicitud(int idUsuario)
        {
            var solicitud = _solicitudes.Where(x => x.IdUsuario == idUsuario).OrderByDescending(x => x.FechaUltimaSolicitud).FirstOrDefault();
            if (solicitud != null)
            {
                _solicitudes.Remove(solicitud);
            }
        }
    }
}
