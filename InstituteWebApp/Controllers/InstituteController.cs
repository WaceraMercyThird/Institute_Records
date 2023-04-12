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
        Uri baseAddress = new Uri("https://localhost:44383/api/");
        
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;

        public InstituteController(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

       

        // GET
        [HttpGet]
        public IActionResult InstituteView()
        {
            try
            {
                List<StudentsModels> studentsList = new List<StudentsModels>();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/api/Students/ GetStudents").Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    studentsList = JsonConvert.DeserializeObject<List<StudentsModels>>(data);



                }

                return View(studentsList);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                throw;
            }
           
        }

       
    }
}

