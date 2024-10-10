using CapaDatos;
using CapaDomain;

var builder = WebApplication.CreateBuilder(args);

// Cargar la configuraci�n desde appsettings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Registrar el patr�n Singleton para la conexi�n a la base de datos
builder.Services.AddSingleton(provider =>
    ConexionSingleton.GetInstance(provider.GetRequiredService<IConfiguration>()));

// Registrar el repositorio y la capa de dominio
builder.Services.AddScoped<AlumnoRepository>();
builder.Services.AddScoped<Alumnodomain>();

builder.Services.AddScoped<clienteRepository>();
builder.Services.AddScoped<clienteDomain>();

builder.Services.AddScoped<proveedorrepository>();
builder.Services.AddScoped<proveedorDomain>();


builder.Services.AddScoped<EmpleadoRepository>();
builder.Services.AddScoped<EmpleadoDomain>();



builder.Services.AddScoped<CompraRepository>();
builder.Services.AddScoped<CompraDomain>();



builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaDomain>();

<<<<<<< HEAD
builder.Services.AddScoped<MetodopagoRepository>();
builder.Services.AddScoped<MetodopagoDomain>();
=======
builder.Services.AddScoped<DetalleVentaRepository>();
builder.Services.AddScoped<DetalleVentaDomain>();
>>>>>>> 951ea4933aef971ac3dc7c04d74bbf55259c35a2

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();