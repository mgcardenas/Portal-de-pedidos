namespace PortalDePedidosServidor.Servicios
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class Convert405To401Middleware
    {
        private readonly RequestDelegate _next;

        public Convert405To401Middleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    // Intentar procesar la solicitud y capturar cualquier excepción de 405
        //    try
        //    {
        //        await _next(context);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (context.Response.StatusCode == StatusCodes.Status405MethodNotAllowed)
        //        {
        //            // Cambiar el código de estado a 401 Unauthorized
        //            context.Response.Clear();
        //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        //            await context.Response.WriteAsync("No autorizado - método no permitido");
        //        }
        //        else
        //        {
        //            throw; // Si no es 405, propagar la excepción
        //        }
        //    }
        //}

        public async Task InvokeAsync(HttpContext context)
        {
            // Obtener el endpoint actual (si existe) para verificar el método permitido
            var endpoint = context.GetEndpoint();

            //si el endpoint no existe o se esta accediendo con un metodo no valido envio error 401
            if (endpoint == null)// || endpoint.Metadata.Count <= 0)
            {
                // Cambiar el código de estado a 401 Unauthorized
                context.Response.Clear();
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("");
            }
            

            // Continuar si el método es permitido
            await _next(context);
        }
    }

}
