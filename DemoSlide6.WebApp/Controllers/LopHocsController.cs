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
    public class LopHocsController : Controller
    {
        public LopHocsController()
        {
            
        }

        // GET: LopHocs
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<LopHoc> lopHocList = new List<LopHoc>();
             using(var http = new HttpClient())
            {
                using(var reponse = await http.GetAsync("https://localhost:7237/api/LopHocs"))
                {
                    string apiRepose = await reponse.Content.ReadAsStringAsync();
                    lopHocList = JsonConvert.DeserializeObject<List<LopHoc>>(apiRepose);
                }
            }
             return View(lopHocList);
        }

        // GET: LopHocs/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.LopHoc == null)
        //    {
        //        return NotFound();
        //    }

        //    var lopHoc = await _context.LopHoc
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (lopHoc == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(lopHoc);
        //}

        //// GET: LopHocs/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: LopHocs/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ClassName,Description")] LopHoc lopHoc)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(lopHoc);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(lopHoc);
        //}

        //// GET: LopHocs/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.LopHoc == null)
        //    {
        //        return NotFound();
        //    }

        //    var lopHoc = await _context.LopHoc.FindAsync(id);
        //    if (lopHoc == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(lopHoc);
        //}

        //// POST: LopHocs/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ClassName,Description")] LopHoc lopHoc)
        //{
        //    if (id != lopHoc.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(lopHoc);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LopHocExists(lopHoc.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(lopHoc);
        //}

        //// GET: LopHocs/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.LopHoc == null)
        //    {
        //        return NotFound();
        //    }

        //    var lopHoc = await _context.LopHoc
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (lopHoc == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(lopHoc);
        //}

        //// POST: LopHocs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.LopHoc == null)
        //    {
        //        return Problem("Entity set 'AppDbContexts.LopHoc'  is null.");
        //    }
        //    var lopHoc = await _context.LopHoc.FindAsync(id);
        //    if (lopHoc != null)
        //    {
        //        _context.LopHoc.Remove(lopHoc);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LopHocExists(int id)
        //{
        //  return (_context.LopHoc?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
