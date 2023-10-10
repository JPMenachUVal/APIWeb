using DAL;
using LogicaNegocio.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Obtener la cadena de conexi�n desde la configuraci�n utilizando el nombre definido en appsettings.json
var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDBConnection");

// Registrar la dependencia ClickMng con la cadena de conexi�n.
builder.Services.AddScoped(_ =>
{
    var mongoClient = new MongoClient(mongoConnectionString);
    var mongoDatabase = mongoClient.GetDatabase("analytics"); // Reemplaza "TuBaseDeDatos" con el nombre de tu base de datos
    return new ClickMng(mongoDatabase);
});

// Registrar la dependencia ClickService.
builder.Services.AddScoped<ClickService>();

// A�adir Swagger para documentaci�n API (si es necesario)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
