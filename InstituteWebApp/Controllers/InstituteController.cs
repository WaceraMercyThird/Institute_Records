#nullable disable
using System.Net.Http.Headers;
using InstituteWebApp.Data.Models;
using InstituteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wonde.EndPoints;

namespace InstituteWebApp.Controllers
{
    public class InstituteController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7183/api/");

        private readonly HttpClient _client;
        private readonly ILogger<StudentsModels> _logger;
        

        public InstituteController(ILogger<StudentsModels> logger)
        {
            
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _logger = logger;
        }



        // GET
        [HttpGet]
        public async Task<IActionResult> InstituteView()
        {
            List<StudentsModels> studentsList = new List<StudentsModels>();

            try
            {
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "Students/GetStudents");

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    studentsList = JsonConvert.DeserializeObject<List<StudentsModels>>(data);



                }

                return View(studentsList);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
               
            }


        }


    }


}

