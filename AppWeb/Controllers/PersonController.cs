using AppWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace AppWeb.Controllers
{
    public class PersonController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7248/api");
        private readonly HttpClient _client;

        public PersonController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PersonViewModel> personList = new List<PersonViewModel>();
            HttpResponseMessage response = await _client.GetAsync("/api/Person");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                personList = JsonConvert.DeserializeObject<List<PersonViewModel>>(data);
            }
            return View(personList);
        }

    }
}
