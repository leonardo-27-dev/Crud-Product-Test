using CrudProduct.Data;
using CrudProduct.Repositories.Interfaces;
using CrudProduct.Repositories.Services;
using CrudProduct.Services.Interfaces;
using CrudProduct.Services.Service;
using CrudProduct.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o DbContext com o SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

// Configuração para escutar na porta definida via variável de ambiente ou usar 80 como padrão
var port = Environment.GetEnvironmentVariable("PORT") ?? "80";

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(int.Parse(port));
});

var app = builder.Build();

DatabaseInitializer.ApplyMigrations(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
