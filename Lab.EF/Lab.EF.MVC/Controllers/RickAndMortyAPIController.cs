using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Lab.EF.MVC.Models.RickAndMortyAPI;

namespace Lab.EF.MVC.Controllers
{
    public class RickAndMortyAPIController : Controller
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyAPIController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
        }

        // GET: RickAndMortyAPI
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("character");

            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("Error", new { message = "Hubo un error al intentar cargar los personajes." });

            RickAndMortyAPI response = await responseMessage.Content.ReadAsAsync<RickAndMortyAPI>();

            List<Character> characters = response.Results;
            
            return View(characters);
        }

        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"character/{id}");

            if (responseMessage.StatusCode == HttpStatusCode.NotFound) return RedirectToAction("Error", new { message = $"No existe un personaje con el id {id}." });
            if (responseMessage.StatusCode == HttpStatusCode.InternalServerError) return RedirectToAction("Error", new { message = "Ha ocurrido un error en el servidor." });

            Character character = await responseMessage.Content.ReadAsAsync<Character>();

            return View(character);
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}