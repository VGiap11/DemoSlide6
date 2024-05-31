using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoSlide6.API.AppDbContext;
using DemoSlide6.API.Model;
using Newtonsoft.Json;

namespace DemoSlide6.WebApp.Controllers
{
    public class StudentsController : Controller
    {

        public StudentsController()
        {
        }

        [HttpGet]
        // GET: Students
        public async Task<IActionResult> Index()
        {
            List<Student> ltsStudents = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var reponse = await httpClient.GetAsync("https://localhost:7237/api/Students"))
                {
                    string apiReponse = await reponse.Content.ReadAsStringAsync();
                    ltsStudents = JsonConvert.DeserializeObject<List<Student>>(apiReponse);
                }
            }
            return View(ltsStudents);
        }

        //GET: Students/Details/5
        [HttpGet("id")]
        public async Task<IActionResult> Details(int? id)
        {
            Student student = new Student();
            using(var httpClient = new HttpClient())
            {
                using(var reponse = await httpClient.GetAsync("https://localhost:7237/api/Students/" + id))
                {
                    if (reponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiReponse = await reponse.Content.ReadAsStringAsync();
                        student = JsonConvert.DeserializeObject<Student>(apiReponse);
                    }
                }
            }
            return View(student);
        }

        //// GET: Students/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Students/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,MaSV")] Student student)
        //{

        //}

        //// GET: Students/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{

        //}

        //// POST: Students/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MaSV")] Student student)
        //{

        //}

        //// GET: Students/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{

        //}

        //// POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{

        //}

        //private bool StudentExists(int id)
        //{

        //}
    }
}
