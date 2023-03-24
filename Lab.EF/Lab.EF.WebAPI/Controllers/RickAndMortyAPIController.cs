using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Lab.EF.WebAPI.Models.RickAndMortyAPI;

namespace Lab.EF.WebAPI.Controllers
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

            RickAndMortyAPI response = await responseMessage.Content.ReadAsAsync<RickAndMortyAPI>();

            List<Character> characters = response.Results;
            
            return View(characters);
        }
    }
}