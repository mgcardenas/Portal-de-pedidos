using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortalDePedidos;
using PortalDePedidosService;
using Blazored.SessionStorage;
using Blazored.Typeahead;
using Microsoft.AspNetCore.Authorization;
using PortalDePedidos.Extensiones;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using PortalDePedidosShared.IngresoPedidosVM;
using PortalDePedidosShared.FacturasVM;
using PortalDePedidosShared.SeguimientoPedidosVM;
using PortalDePedidosShared.LoginVM;
using PortalDePedidosShared.RecibosVM;
using PortalDePedidosShared.RemitosVM;
using PortalDePedidosShared.CuentasCorrientesVM;
using PortalDePedidosShared.EstadisticasVM;
using System.Globalization;
using Microsoft.JSInterop;
using PortalDePedidosShared.ComprasAnticipadasPendientesVM;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Manejo de AppSettings si hay que agragar variables se agregan al json y a la clase AppSettings
string json = System.IO.File.ReadAllText("/appsettings.json");

AppSettings appSettings = JsonConvert.DeserializeObject<AppSettings>(json);

builder.Services.AddSingleton(appSettings);

//HttClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(appSettings.ApiConnection) });


//Servicios
builder.Services.AddScoped<LogClienteService>();
builder.Services.AddScoped<LogInClienteService>();
builder.Services.AddScoped<ArticuloClienteService>();
builder.Services.AddScoped<UsuarioClienteService>();
builder.Services.AddScoped<ContactoClienteService>();
builder.Services.AddScoped<PagoService>();
builder.Services.AddScoped<ErrorService>();
builder.Services.AddScoped<ReCaptchaClienteService>();
builder.Services.AddScoped<AuditoriaClienteService>();
builder.Services.AddScoped<DataWareHouseClienteService>();
builder.Services.AddScoped<IngresoPedidoClienteService>();
builder.Services.AddScoped<ImagenClienteService>();
builder.Services.AddScoped<ExcelService>();
builder.Services.AddScoped<PdfClienteService>();
builder.Services.AddScoped<EstadisticaClienteService>();
builder.Services.AddScoped<ImagenAleatoriaClienteService>();
builder.Services.AddScoped<ImagenCarruselClienteService>();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    }).AddBootstrapProviders()
    .AddFontAwesomeIcons();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<ISessionRepository, SessionRepository>(); // <-- nueva línea: repositorio de sesión
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore();



//contenedor
builder.Services.AddSingleton<CarritoPedidosContainer>();
builder.Services.AddSingleton<FacturasContainer>();
builder.Services.AddSingleton<SeguimientoPedidosContainer>();
builder.Services.AddSingleton<SeguimientoPedidosVentaAnticipadaContainer>();
builder.Services.AddSingleton<LoginContainer>();
builder.Services.AddSingleton<ReciboContainer>();
builder.Services.AddSingleton<RemitosContainer>();
builder.Services.AddSingleton<CuentasCorrientesContainer>();
builder.Services.AddSingleton<EstadisticaContainer>();
builder.Services.AddSingleton<ComprasAnticipadasPendientesContainer>();

//Manejador de contenedores
builder.Services.AddScoped<ContainerManager>();

//configurar cookies
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
    options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
    options.Secure = CookieSecurePolicy.Always;
});

//aseguro la configuracion para evitar errores de fechas
//CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
//CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-ES");
var host = builder.Build();
using (var scope = host.Services.CreateScope())
{
    var js = scope.ServiceProvider.GetRequiredService<IJSRuntime>();
    //js.InvokeVoidAsync("location.reload", true);
    // Verificar y recargar solo una vez
    if (await js.InvokeAsync<bool>("versionManager.shouldReload"))
    {
        //var msj = "Si la App no carga se recomienda borrar el cache.";
        //await js.InvokeVoidAsync("AlertaArticulo", msj);
        //await js.InvokeVoidAsync("versionManager.reload");
    }
}
await host.RunAsync();
