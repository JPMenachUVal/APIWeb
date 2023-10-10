using DAL;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LogicaNegocio.Services
{
    public class ClickService
    {
        private readonly ClickMng _clickMng;

        public ClickService(IConfiguration configuration)
        {
            // Obtén la cadena de conexión desde el archivo appsettings.json
            string mongoConnectionString = configuration.GetConnectionString("MongoDBConnection");

            // Configura la conexión a MongoDB utilizando el cliente y la base de datos
            var mongoClient = new MongoClient(mongoConnectionString);
            var mongoDatabase = mongoClient.GetDatabase("analytics"); // Reemplaza "TuBaseDeDatos" con el nombre de tu base de datos

            // Crea una instancia de ClickMng pasando el objeto IMongoDatabase
            _clickMng = new ClickMng(mongoDatabase);
        }

        public async Task InsertarClickAsync(Click click)
        {
            // Aquí puedes realizar validaciones u operaciones adicionales antes de insertar el clic.
            await _clickMng.InsertarClickAsync(click);
        }

        public async Task<List<Click>> ObtenerTodosLosClicksAsync()
        {
            return await _clickMng.ObtenerTodosLosClicksAsync();
        }

        // Puedes agregar más métodos de lógica de negocio según tus necesidades
    }
}
