using CapaDatos;
using CapaDomain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Cargar la configuración desde appsettings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Registrar el patrón Singleton para la conexión a la base de datos
builder.Services.AddSingleton(provider =>
    ConexionSingleton.GetInstance(provider.GetRequiredService<IConfiguration>()));

// Registrar el repositorio y la capa de dominio
builder.Services.AddScoped<AlumnoRepository>();
builder.Services.AddScoped<Alumnodomain>();


builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ClienteDomain>();


builder.Services.AddScoped<DetallecompraDomain>();
builder.Services.AddScoped<DetallecompraRepository>();


builder.Services.AddScoped<proveedorrepository>();
builder.Services.AddScoped<proveedorDomain>();


builder.Services.AddScoped<EmpleadoRepository>();
builder.Services.AddScoped<EmpleadoDomain>();


builder.Services.AddScoped<CompraRepository>();
builder.Services.AddScoped<CompraDomain>();


builder.Services.AddScoped<VentaRepository>();
builder.Services.AddScoped<VentaDomain>();


builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaDomain>();


builder.Services.AddScoped<MetodopagoRepository>();
builder.Services.AddScoped<MetodopagoDomain>();

builder.Services.AddScoped<DetalleVentaRepository>();
builder.Services.AddScoped<DetalleVentaDomain>();


builder.Services.AddScoped<PagoRepository>();
builder.Services.AddScoped<PagoDomain>();


builder.Services.AddScoped<productodomain>();
builder.Services.AddScoped<productorepository>();

// Registrar los controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();