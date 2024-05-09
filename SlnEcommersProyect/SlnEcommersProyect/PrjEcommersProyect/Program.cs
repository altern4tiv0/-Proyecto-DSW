 using Microsoft.EntityFrameworkCore;
using PrjEcommersProyect.DAO;
using PrjEcommersProyect.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UsuarioDAO>();

string cad_cn = builder.Configuration.GetConnectionString("cn1");

builder.Services.AddDbContext<EcommersProyectContext>(
    opt => opt.UseSqlServer(cad_cn));

builder.Services.AddSession(
    s => s.IdleTimeout = TimeSpan.FromMinutes(20));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// activar las sesiones
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Producto}/{action=ListaProductos}/{id?}");

app.MapControllerRoute(
    name: "default2",
    pattern: "{controller=Usuario}/{action=ValidarIngreso}/{id?}");




app.Run();
