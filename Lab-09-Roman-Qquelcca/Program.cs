using Examen_Roman_Qquelcca.Repositories.Interfaces;
using Lab_09_Roman_Qquelcca.Models;
using Lab_09_Roman_Qquelcca.Reports.Excel;
using Lab_09_Roman_Qquelcca.Repositories;
using Lab_09_Roman_Qquelcca.Repositories.Unit;
using Lab_09_Roman_Qquelcca.Services;
using Lab_09_Roman_Qquelcca.Services.LINQ;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración de DbContext con MySQL
builder.Services.AddDbContext<LinQDBContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar los repositorios genéricos
builder.Services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
builder.Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
builder.Services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();

// Registrar los LINQ
// Registrar servicios LINQ
builder.Services.AddScoped<GetClientsWithOrders>();
builder.Services.AddScoped<GetOrdersWithDetails>();
builder.Services.AddScoped<GetSalesByClient>();
builder.Services.AddScoped<GetClientsWithProductCount>();
builder.Services.AddScoped<ExcelReportService>();
builder.Services.AddScoped<ExcelReportService>();
builder.Services.AddScoped<Generar_Reporte_Clientes>();
builder.Services.AddScoped<Generar_Reporte_Detalles>();



// Registrar UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Agregar servicios de Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// Habilitar middleware de Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty; // Esto hace que Swagger UI esté disponible en la raíz
});

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();