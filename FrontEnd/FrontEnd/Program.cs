using FrontEnd.Servicio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EstaEsUnaClaveMuySeguraYDeAlMenos32Caracteres")) // clave secreta simulada
    };
});


/*

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
*/

builder.Services.AddAuthorization();

builder.Services.AddHttpClient<TokenService>();
builder.Services.AddScoped<TokenService>();
//builder.Services.AddControllersWithViews();
//builder.Services.AddHttpClient<ICategoriaService, CategoriaService>();
builder.Services.AddHttpClient<CategoriaService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddHttpClient<ProductoService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddHttpClient<ProveedorService>();
builder.Services.AddScoped<ProveedorService>();
builder.Services.AddHttpClient<EmpleadoService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddHttpClient<ClienteService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddHttpClient<MetodopagoService>();
builder.Services.AddScoped<MetodopagoService>();
builder.Services.AddHttpClient<CompraService>();
builder.Services.AddScoped<CompraService>();
builder.Services.AddHttpClient<ventaService>();
builder.Services.AddScoped<ventaService>();
builder.Services.AddHttpClient<DetalleVentaService>();
builder.Services.AddScoped<DetalleVentaService>();
builder.Services.AddHttpClient<DetallecompraService>();
builder.Services.AddScoped<DetallecompraService>();
builder.Services.AddHttpClient<PagoService>();
builder.Services.AddScoped<PagoService>();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseSession();
//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
