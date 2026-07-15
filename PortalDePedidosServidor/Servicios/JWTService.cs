using Microsoft.IdentityModel.Tokens;
using PortalDePedidosModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortalDePedidosServidor.Servicios
{
    public class JWTService
    {
        private IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetAccessToken(SesionUsuario sesion)
        {
            // Crear las reclamaciones (claims) para el JWT
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, sesion.NombreUsuario),
                new Claim(ClaimTypes.Role, sesion.Rol)
            };

            // Crear el token JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetConnectionString("contrasenaJWT")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,  // Puedes especificar el emisor si es necesario
                audience: null, // Puedes especificar la audiencia si es necesario
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration.GetConnectionString("tiempoExpiracionJWT"))), // Tiempo de expiración
                signingCredentials: creds);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
