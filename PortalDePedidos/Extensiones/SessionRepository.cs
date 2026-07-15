using Blazored.SessionStorage;
using PortalDePedidosModel;
using System.Threading.Tasks;

namespace PortalDePedidos.Extensiones
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ISessionStorageService _sessionStorageService;
        private readonly AppSettings _appSettings;

        public SessionRepository(ISessionStorageService sessionStorageService, AppSettings appSettings)
        {
            _sessionStorageService = sessionStorageService;
            _appSettings = appSettings;
        }

        public async Task GuardarSesionAsync(SesionUsuario sesionUsuario)
        {
            if (sesionUsuario != null)
            {
                // Política de expiración centralizada en el repositorio de sesión
                sesionUsuario.Expiracion = DateTime.Now.AddMinutes(_appSettings.DuracionSesion);
                await _sessionStorageService.GuargarStorage("sesionUsuario", sesionUsuario);
            }
        }

        public async Task<SesionUsuario?> ObtenerSesionAsync()
        {
            return await _sessionStorageService.ObtenerStorage<SesionUsuario>("sesionUsuario");
        }

        public async Task RemoverSesionAsync()
        {
            await _sessionStorageService.RemoveItemAsync("sesionUsuario");
        }
    }
}