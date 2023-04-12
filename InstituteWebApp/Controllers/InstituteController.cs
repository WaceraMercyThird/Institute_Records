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
        private readonly ApplicationDbContext _context;

        public InstituteController(ApplicationDbContext context, ILogger<StudentsModels> logger)
        {
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _logger = logger;
        }

       

        // GET
       
        public IActionResult InstituteView()
        {
            try
            {
                return View("InstituteView");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
            

        }

        [HttpGet]
        public List<StudentsModels> GetRecords()
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

                return studentsList;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

       
    }
}

