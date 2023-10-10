using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades; // Asegúrate de importar el espacio de nombres correcto
using LogicaNegocio.Services; // Asegúrate de importar el espacio de nombres correcto
using Microsoft.AspNetCore.Mvc;

namespace MongoAPI.Controllers
{
    [ApiController]
    [Route("api/clicks")]
    public class ClickController : ControllerBase
    {
        private readonly ClickService _clickService;

        public ClickController(ClickService clickService)
        {
            _clickService = clickService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarClickAsync(Click click)
        {
            try
            {
                // Aquí puedes realizar validaciones adicionales si es necesario
                await _clickService.InsertarClickAsync(click);
                return Ok("Click insertado con éxito");
            }
            catch (Exception ex)
            {
                // Maneja las excepciones según tus necesidades
                return BadRequest($"Error al insertar el click: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosClicksAsync()
        {
            try
            {
                var clicks = await _clickService.ObtenerTodosLosClicksAsync();
                return Ok(clicks);
            }
            catch (Exception ex)
            {
                // Maneja las excepciones según tus necesidades
                return BadRequest($"Error al obtener los clicks: {ex.Message}");
            }
        }

        // Puedes agregar más rutas y métodos según tus necesidades
    }
}
