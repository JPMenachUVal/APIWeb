using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClickMng
    {
        private readonly IMongoCollection<Click> _clicks;

        public ClickMng(IMongoDatabase database)
        {
            _clicks = database.GetCollection<Click>("Clicks");
        }

        public async Task InsertarClickAsync(Click click)
        {
            try
            {
                await _clicks.InsertOneAsync(click);
            }
            catch (Exception ex)
            {
                // Maneja las excepciones según tus necesidades
                throw ex;
            }
        }

        public async Task<List<Click>> ObtenerTodosLosClicksAsync()
        {
            try
            {
                return await _clicks.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // Maneja las excepciones según tus necesidades
                throw ex;
            }
        }

        // Puedes agregar más métodos de acceso a datos según tus necesidades
    }
}
