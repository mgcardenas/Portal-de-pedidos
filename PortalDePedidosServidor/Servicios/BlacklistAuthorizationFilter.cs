namespace PortalDePedidosServidor.Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.Extensions.DependencyInjection;

    public class BlacklistAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // Obtener el servicio TokenBlacklistService desde el contenedor de dependencias
            var blacklistService = context.HttpContext.RequestServices.GetService<TokenBlacklistService>();

            if (blacklistService != null && blacklistService.IsBlacklisted(token))
            {
                // Si el token está en la lista negra, devolver un 401 (Unauthorized)
                context.Result = new UnauthorizedResult();
            }
        }
    }

}
