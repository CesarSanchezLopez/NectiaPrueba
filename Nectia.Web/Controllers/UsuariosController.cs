using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Models;
//using Nectia.Api.Data;
using Newtonsoft.Json;

namespace Nectia.Web.Controllers
{
    public class UsuariosController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "https://localhost:7089/";

        public UsuariosController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            List<Usuario> UserInfo = new List<Usuario>();
            using (var client = new HttpClient())
            {
              
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
              
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
              
                HttpResponseMessage Res = await client.GetAsync("api/Usuarios");
             
                if (Res.IsSuccessStatusCode)
                {
                  
                    var UserResponse = Res.Content.ReadAsStringAsync().Result;
                 
                    UserInfo = JsonConvert.DeserializeObject<List<Usuario>>(UserResponse);
                }
             
                return View(UserInfo);
            }
        }
        //New
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Get(Usuario usuario)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "api/Usuarios/");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {

                Usuario myObject;
                myObject = new Usuario
                {
                    User   = collection["User"][0],
                    Password  = collection["Password"][0],
                    PrimerNombre = collection["PrimerNombre"][0],
                    SegundoNombre = collection["SegundoNombre"][0]


                };
                JsonContent content = JsonContent.Create(myObject);

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.PostAsync("api/Usuarios", content);

                    if (Res.IsSuccessStatusCode)
                    {

                        var MonResponse = Res.Content.ReadAsStringAsync().Result;

                    }


                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int Id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "api/Usuarios/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var usuario = JsonConvert.DeserializeObject<Usuario>(responseData);

                return View(usuario);
            }
            return View("Error");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Usuario usuario)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "api/Usuarios/" + id, usuario);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        public async Task<ActionResult> Details(int Id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "api/Usuarios/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var usuario = JsonConvert.DeserializeObject<Usuario>(responseData);

                return View(usuario);
            }
            return View("Error");

        }

        public ActionResult Delete(int id)
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Usuario monedas)
        {
          

            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "api/Usuarios/" + id);
            if (responseMessage.IsSuccessStatusCode)

            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
       

    }
}
