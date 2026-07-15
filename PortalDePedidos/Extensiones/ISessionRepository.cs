
namespace PortalDePedidos.Extensiones
{
    using PortalDePedidosModel;
    using System.Threading.Tasks;

    public interface ISessionRepository
    {
        Task GuardarSesionAsync(SesionUsuario sesionUsuario);
        Task<SesionUsuario?> ObtenerSesionAsync();
        Task RemoverSesionAsync();
    }
}