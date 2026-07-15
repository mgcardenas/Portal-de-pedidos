using Blazored.SessionStorage;
using System.Text.Json;

namespace PortalDePedidos.Extensiones
{
    public static class SessionStorageExtension
    {
        public static async Task GuargarStorage<T>(
            this ISessionStorageService sessionStorageService,
            string key, T item
            ) where T : class
        {
            var itemJson = JsonSerializer.Serialize(item);
            await sessionStorageService.SetItemAsStringAsync(key, itemJson);
        }

        public static async Task<T?> ObtenerStorage<T>(
            this ISessionStorageService sessionStorageService,
            string key
            ) where T : class
        {
            var itemJson = await sessionStorageService.GetItemAsStringAsync(key);

            if (string.IsNullOrEmpty(itemJson))
            {
                return null;
            }

            return JsonSerializer.Deserialize<T>(itemJson);
        }
    }
}
