using Microsoft.AspNetCore.Mvc;
using NZWalks.WebApp.Models;

namespace NZWalks.WebApp.Controllers
{
    public class AuthController : Controller
    {
        
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public AuthController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
            {
                _httpClientFactory = httpClientFactory;
                _httpContextAccessor = httpContextAccessor;
            }

            [HttpGet]
            public IActionResult Login1()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login1(LoginRequestVM login)
            {
                if (!ModelState.IsValid)
                    return View(login);

                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("http://localhost:5085/api/Auth/Login", login);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }     
    }
           
}
