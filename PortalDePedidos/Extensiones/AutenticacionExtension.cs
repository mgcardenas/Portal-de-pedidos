using Microsoft.AspNetCore.Components.Authorization;
using PortalDePedidosModel;
using System.Security.Claims;

namespace PortalDePedidos.Extensiones
{
    public class AutenticacionExtension : AuthenticationStateProvider
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ClaimsPrincipal _sinInformacion = new(new ClaimsIdentity());

        public AutenticacionExtension(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task ActualizarEstadoAutenticacion(SesionUsuario? sesionUsuario )
        {
            ClaimsPrincipal claimsPrincipal;
            if (sesionUsuario != null)
            {
                claimsPrincipal = BuildClaimsPrincipal(sesionUsuario);
                // Delegamos persistencia y expiración al repositorio
                await _sessionRepository.GuardarSesionAsync(sesionUsuario);
            }
            else
            {
                claimsPrincipal = _sinInformacion;
                await _sessionRepository.RemoverSesionAsync();
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task ExpirarSesion()
        {
            await _sessionRepository.RemoverSesionAsync();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_sinInformacion)));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesionUsuario = await _sessionRepository.ObtenerSesionAsync();

            if (sesionUsuario == null)
                return new AuthenticationState(_sinInformacion);

            var claimsPrincipal = BuildClaimsPrincipal(sesionUsuario);
            return new AuthenticationState(claimsPrincipal);
        }

        private static ClaimsPrincipal BuildClaimsPrincipal(SesionUsuario sesionUsuario)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, sesionUsuario.NombreUsuario),
                new Claim(ClaimTypes.Email, sesionUsuario.Correo),
                new Claim(ClaimTypes.Role, sesionUsuario.Rol)
            }, "JwtAuth"));
        }
    }
}
