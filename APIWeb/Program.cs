using LogicaNegocio.Services;
using LogicaNegocio;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();

// Obtener la cadena de conexi�n desde la configuraci�n utilizando el nombre definido en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar la dependencia PersonService con la cadena de conexi�n.
builder.Services.AddScoped(_ => new PersonService(connectionString));

// Registrar la dependencia TransactionService con la cadena de conexi�n.
builder.Services.AddScoped(_ => new TransactionService(connectionString));

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