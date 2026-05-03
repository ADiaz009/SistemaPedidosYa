using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SistemaPedidosYa.AppContext;
using SistemaPedidosYa.Interfaces;
using SistemaPedidosYa.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de Mongo desde appsettings.json
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

// 2. Registro del Cliente de MongoDB
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// 3. ¡ESTA ES LA PIEZA CLAVE! Registramos el MongoDBContext
// Esto permite que PedidosRepository y los demás puedan recibirlo en su constructor
builder.Services.AddSingleton<MongoDBContext>();

// 4. Registro de Repositorios
builder.Services.AddScoped<IPedidoRepository, PedidosRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();