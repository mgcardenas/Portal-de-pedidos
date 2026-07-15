namespace PortalDePedidosServidor.Servicios
{
    public class TokenBlacklistService
    {
        private static readonly HashSet<string> _blacklistedTokens = new HashSet<string>();
        private static readonly HashSet<string> _TokenGenerados = new HashSet<string>();

        // Añadir el token a la lista negra
        public void AddToBlacklist(string token)
        {
            _blacklistedTokens.Add(token);
        }

        // Comprobar si el token está en la lista negra
        public bool IsBlacklisted(string token)
        {
            return _blacklistedTokens.Contains(token);
        }

        // Añadir el token a la lista de token generados
        public void AddToTokenGeneradosList(string token)
        {
            _TokenGenerados.Add(token);
        }

        // Comprobar si el token está en la lista negra
        public bool EsTokenGenerado(string token)
        {
            return _TokenGenerados.Contains(token);
        }
    }

}
