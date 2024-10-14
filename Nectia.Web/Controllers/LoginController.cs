using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Nectia.Web.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Diagnostics;
using Nectia.Web.Models;

namespace Nectia.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        HttpClient client;
        //The URL of the WEB API Service
        string url = "https://localhost:7089/";
        public LoginController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }



        [HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuario model)
        {
            using (var client = new HttpClient())
            {
                List<Usuario> UserInfo = new List<Usuario>();
              
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              
                HttpResponseMessage Res = await client.GetAsync("api/Usuarios");
              
                if (Res.IsSuccessStatusCode)
                {
                   
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;
                   
                    UserInfo = JsonConvert.DeserializeObject<List<Usuario>>(UserResponse);

                  
                    var user = UserInfo.Where(Usuario => Usuario.User.ToLower() == model.User.ToLower() && Usuario.Password.ToLower() == model.Password.ToLower());
                    if (user.Count() != 0)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        ViewBag.Error = "Usuario no existe";
                        RedirectToAction("Login");
                     
                    }
                }
                return View();

            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
