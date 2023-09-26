using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Entidades;
//using LogicaNegocio.Services;
using LogicaNegocio;

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService personService;

        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] Person person)
        {
            try
            {
                personService.AddUser(person);
                return Ok("Usuario añadido correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al añadir usuario: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult GetPersons()
        {
            try
            {
                var persons = personService.GetPersons();
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener la lista de personas: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeletePersonsByName")]
        public IActionResult DeletePersonsByName(string name)
        {
            try
            {
                int affectedRows = personService.DeletePersonsByName(name);

                if (affectedRows > 0)
                {
                    return Ok($"Se eliminaron {affectedRows} registros de Person con el nombre '{name}'.");
                }
                else
                {
                    return NotFound($"No se encontraron registros de Person con el nombre '{name}' para eliminar.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar registros de Person por nombre: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] Person person)
        {
            try
            {
                personService.UpdateUser(person);
                return Ok("Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar usuario: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(int id, string newPassword)
        {
            try
            {
                int affectedRows = personService.ChangePassword(id, newPassword);

                if (affectedRows > 0)
                {
                    return Ok("La contraseña se ha cambiado exitosamente.");
                }
                else
                {
                    return NotFound($"No se encontró el usuario con el Id '{id}' para cambiar la contraseña.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al cambiar la contraseña: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetPersonsByName")]
        public IActionResult GetPersonsByName(string name)
        {
            try
            {
                var persons = personService.GetPersonsByName(name);

                if (persons != null && persons.Count > 0)
                {
                    return Ok(persons);
                }
                else
                {
                    return NotFound("No se encontraron personas con ese nombre.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener personas por nombre: {ex.Message}");
            }
        }
        // GET: PersonController
        /*public ActionResult Index()
        {
            return View();
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
