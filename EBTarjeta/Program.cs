using EBTarjeta;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios en el contenedor de dependencias.
// Añadir Razor Pages y Controllers (API) para que el proyecto soporte ambas superficies.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Configurar el DbContext usando la cadena de conexión definida en appsettings.json.
// Aquí se selecciona SQL Server como proveedor.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

// Política CORS usada durante desarrollo para permitir que la app Angular (localhost:4200) consuma la API.
builder.Services.AddCors(options => options.AddPolicy("AllowAllAngularApp", p => p.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configuración del pipeline HTTP.
// En entornos no desarrollo se usa un handler de excepciones y HSTS por seguridad.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // HSTS por defecto 30 días; ajustar según políticas de despliegue.
    app.UseHsts();
}

// Habilitar CORS con la política definida anteriormente.
app.UseCors("AllowAllAngularApp");

// Redirección a HTTPS y servir archivos estáticos configurados en wwwroot.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Autorización (si se añade autenticación/autorización se configura aquí).
app.UseAuthorization();

// Mapear endpoints de API y Razor Pages.
app.MapControllers();
app.MapRazorPages();

app.Run();
