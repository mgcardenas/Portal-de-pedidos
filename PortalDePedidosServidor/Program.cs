using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PortalDePedidosServidor;
using PortalDePedidosServidor.Models;
using PortalDePedidosServidor.ModelsDataWhereHouse;
using PortalDePedidosServidor.Servicios;
using System.Net;
using System.Text;
using PortalDePedidosShared.EstadisticasVM;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using Microsoft.OpenApi.Models; // añadido para Swagger
using System.IO;
using Microsoft.AspNetCore.Diagnostics; // para UseExceptionHandler
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PortalDePedidosServidor.ModelsJDE;

var builder = WebApplication.CreateBuilder(args);

string MiCors = "MyCors";
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MiCors,
        builder =>
        {
            builder.WithOrigins(allowedOrigins)
                   .AllowAnyHeader()
                   .AllowAnyMethod();
                   //.AllowCredentials(); // Si necesitas enviar cookies o credenciales
        });
});

// Add services to the container.
// Añadimos configuración para respuestas de validación (ProblemDetails)
builder.Services.AddControllers();

// Configurar respuesta para errores de validación y que sea application/problem+json
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Title = "One or more validation errors occurred.",
            Status = StatusCodes.Status400BadRequest,
            Instance = context.HttpContext.Request.Path
        };

        return new BadRequestObjectResult(problemDetails)
        {
            ContentTypes = { "application/problem+json" }
        };
    };
});

// Swagger / OpenAPI: añadir metadatos y seguridad Bearer (documentación y testing con JWT)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Document info (puede leer versión desde configuración si se desea)
    var versionMayor = builder.Configuration.GetConnectionString("VersionMayor") ?? "1";
    var versionMenor = builder.Configuration.GetConnectionString("VersionMenor") ?? "0";
    c.SwaggerDoc($"v{versionMayor}.{versionMenor}", new OpenApiInfo
    {
        Title = "PortalDePedidos API",
        Version = $"v{versionMayor}.{versionMenor}",
        Description = "API REST del Portal de Pedidos (Blazor WebAssembly cliente, .NET 8 servidor)"
    });

    // JWT Bearer definition to test endpoints desde Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Ingrese: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] { }
        }
    });

    // Incluir comentarios XML si existen (mejora documentación)
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddHttpClient();
// Registrar memoria en cache para optimizaciones de rendimiento
builder.Services.AddMemoryCache();
//Servicios
builder.Services.AddScoped<LogService>();
builder.Services.AddScoped<MailService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<RecaptchaService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<DataWareHouseService>();
builder.Services.AddScoped<ArticuloService>();
builder.Services.AddScoped<AuditoriasService>();
builder.Services.AddScoped<JDEService>();
builder.Services.AddScoped<IngresoPedidoService>();
builder.Services.AddScoped<ImagenService>();
builder.Services.AddScoped<PDFService>();
builder.Services.AddScoped<PdfToBase64Service>();
builder.Services.AddScoped<EstadisticaService>();
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<ImagenAleatoriaService>();
builder.Services.AddScoped<ImagenCarruselService>();
builder.Services.AddScoped<SolicitudContrasenaService>();
builder.Services.AddScoped<BloqueoLogInService>();
builder.Services.AddScoped<LogInMFAService>();


//RateLimiting
// Configurar rate limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy("token", context =>
     {
         // Usar IP o usuario logueado
         var partitionKey = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

         return RateLimitPartition.GetTokenBucketLimiter(partitionKey, _ => new TokenBucketRateLimiterOptions
         {
             TokenLimit = 2,                      // máximo tokens
             TokensPerPeriod = 2,                 // cuántos se agregan por período
             ReplenishmentPeriod = TimeSpan.FromSeconds(30),
             QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
             QueueLimit = 0,
             AutoReplenishment = true
         });
     });

    // Respuesta personalizada
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        context.HttpContext.Response.ContentType = "application/json";

        var problem = new
        {
            error = "TooManyRequests",
            message = "Demasiadas solicitudes, intentá de nuevo más tarde."
        };

        await context.HttpContext.Response.WriteAsJsonAsync(problem, cancellationToken: token);
    };

});

// Registrar el proveedor de codificación en toda la aplicación
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

//Servicio para acceder a red
string networkPath = builder.Configuration.GetConnectionString("networkPath");
string username = builder.Configuration.GetConnectionString("networkUsername");
string password = builder.Configuration.GetConnectionString("networkPassword");

var credentials = new NetworkCredential(username, password);

builder.Services.AddSingleton(new AccesoARedService(networkPath,credentials));


//Contexto a base de datos
var connString = builder.Configuration.GetConnectionString("ConexionDB");
builder.Services.AddDbContext<PortalTestContext>(options => options.UseSqlServer(connString));

var connStringDWH = builder.Configuration.GetConnectionString("ConexionDataWhereHouse");
builder.Services.AddDbContext<PortalClienteDataWherehouseContext>(options => options.UseSqlServer(connStringDWH));

var connStringJDE = builder.Configuration.GetConnectionString("ConexionJDE");
// Crear una instancia de Schema y asignar el valor inicial
var schemaInstance = new Schema { schema = builder.Configuration.GetConnectionString("SchemaJDE") };

// Registrar Schema como singleton
builder.Services.AddSingleton(schemaInstance);
builder.Services.AddDbContext<JdeContext>(options => options.UseSqlServer(connStringJDE));

// JWT para seguridad de la API
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetConnectionString("contrasenaJWT")); // Cambia esto por tu clave secreta

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false, // Puedes establecer tu emisor si es necesario
        ValidateAudience = false, // Puedes establecer la audiencia si es necesario
        RequireExpirationTime = false,
        ValidateLifetime = true
    };
});

// Añadir filtro de autorización como servicio
builder.Services.AddScoped<TokenBlacklistService>();
builder.Services.AddScoped<BlacklistAuthorizationFilter>();

builder.Services.AddAuthorization();

var versionMayor = int.Parse(builder.Configuration.GetConnectionString("VersionMayor"));
var versionMenor = int.Parse(builder.Configuration.GetConnectionString("VersionMenor"));

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true; // Muestra las versiones disponibles en las respuestas
    options.AssumeDefaultVersionWhenUnspecified = true; // Si no se especifica versión, usa la por defecto
    options.DefaultApiVersion = new ApiVersion(versionMayor, versionMenor); // Versión por defecto
    options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version"); // Leer versión desde el header
});

//Contenedores
//builder.Services.AddSingleton<DatosContainer>();

var app = builder.Build();

app.UseCors(MiCors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Mostrar el documento con la versión detectada en config (si aplica)
        var version = $"v{versionMayor}.{versionMenor}";
        c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"PortalDePedidos API {version}");
        c.RoutePrefix = "swagger";
    });
}

// Middleware global de manejo de excepciones que devuelve ProblemDetails (application/problem+json)
app.UseExceptionHandler(errApp =>
{
    errApp.Run(async context =>
    {
        var exFeature = context.Features.Get<IExceptionHandlerFeature>();
        var ex = exFeature?.Error;

        var problemDetails = new ProblemDetails
        {
            Title = "An unexpected error occurred.",
            Detail = ex?.Message,
            Status = StatusCodes.Status500InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Instance = context.Request.Path
        };

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";
        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});

app.UseHttpsRedirection();

// Configuración de encabezados de seguridad
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");

    // Establece el encabezado X-Content-Type-Options
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");

    // Sobrescribe el encabezado con un valor genérico
    context.Response.Headers["Server"] = "Generico"; 
    // Establece Content-Type en respuestas sin un tipo explícito
    if (!context.Response.Headers.ContainsKey("Content-Type"))
    {
        context.Response.Headers.Add("Content-Type", "application/json"); // Ajusta el tipo de contenido según la necesidad
    }

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

// Registrar el middleware personalizado para convertir 405 a 401
app.UseMiddleware<Convert405To401Middleware>();
//app.MapControllers();

// Activar el rate limiter
app.UseRateLimiter();

app.MapControllers();
   //.RequireRateLimiting("fixed"); // aplicar a todos los controladores

app.Run();
