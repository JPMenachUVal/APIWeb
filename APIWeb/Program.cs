using LogicaNegocio.Services;
using LogicaNegocio;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Obtener la cadena de conexión desde la configuración utilizando el nombre definido en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar la dependencia PersonService con la cadena de conexión.
builder.Services.AddScoped(_ => new PersonService(connectionString));

// Registrar la dependencia TransactionService con la cadena de conexión.
builder.Services.AddScoped(_ => new TransactionService(connectionString));

// Añadir Swagger para documentación API (si es necesario)
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