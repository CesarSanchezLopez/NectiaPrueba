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
    public class VehiculosController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        //string url = "https://localhost:7089/";
        string url { get; }
        public IConfiguration Configuration { get; }
        public VehiculosController(IConfiguration configuration)
        {
            Configuration = configuration;
          
            url = Configuration.GetValue<string>("URLApi:URLApiKey");

            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            List<Vehiculo> VehiculoInfo = new List<Vehiculo>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Vehiculos");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var VehiculoResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    VehiculoInfo = JsonConvert.DeserializeObject<List<Vehiculo>>(VehiculoResponse);
                }
                //returning the employee list to view
                return View(VehiculoInfo);
            }


        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Get(Vehiculo vehiculo)
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

        // POST: MonedasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {

                Vehiculo myObject;
                myObject = new Vehiculo
                {
                    Nombre = collection["Nombre"][0],
                    Descripcion = collection["Descripcion"][0],
                    Chasis = collection["Chasis"][0],
                    Kilometraje = Convert.ToInt32(collection["Kilometraje"][0]),
                    Color = collection["Color"][0],
                    Valor = Convert.ToDecimal(collection["Valor"][0]),
                    Tipo = collection["Tipo"][0],
                    Modelo = collection["Modelo"][0],
                    Marca = collection["Marca"][0],
                    Placa = collection["Placa"][0],
                    Version = collection["Version"][0],

                };
                JsonContent content = JsonContent.Create(myObject);

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.PostAsync("api/Vehiculos", content);

                    if (Res.IsSuccessStatusCode)
                    {

                        var MonResponse = Res.Content.ReadAsStringAsync().Result;

                    }


                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<ActionResult> Edit(int Id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "api/Vehiculos/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var vehiculo = JsonConvert.DeserializeObject<Vehiculo>(responseData);

                return View(vehiculo);
            }
            return View("Error");

        }

        public async Task<ActionResult> Details(int Id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "api/Vehiculos/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var vehiculo = JsonConvert.DeserializeObject<Vehiculo>(responseData);

                return View(vehiculo);
            }
            return View("Error");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Vehiculo vehiculo)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "api/Vehiculos/" + id, vehiculo);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Vehiculo vehiculo)
        {


            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "api/Vehiculos/" + id);
            if (responseMessage.IsSuccessStatusCode)

            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}
