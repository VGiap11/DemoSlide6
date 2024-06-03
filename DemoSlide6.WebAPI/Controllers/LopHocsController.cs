using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoSlide6.API.AppDbContext;
using DemoSlide6.API.Model;

namespace DemoSlide6.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocsController : ControllerBase
    {
        private readonly AppDbContexts _context;

        public LopHocsController(AppDbContexts context)
        {
            _context = context;
        }

        // GET: api/LopHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LopHoc>>> GetLopHoc()
        {
          if (_context.LopHoc == null)
          {
              return NotFound();
          }
            return await _context.LopHoc.ToListAsync();
        }

        // GET: api/LopHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LopHoc>> GetLopHoc(int id)
        {
          if (_context.LopHoc == null)
          {
              return NotFound();
          }
            var lopHoc = await _context.LopHoc.FindAsync(id);

            if (lopHoc == null)
            {
                return NotFound();
            }

            return lopHoc;
        }

        // PUT: api/LopHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLopHoc(int id, LopHoc lopHoc)
        {
            if (id != lopHoc.Id)
            {
                return BadRequest();
            }

            _context.Entry(lopHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LopHocExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LopHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LopHoc>> PostLopHoc(LopHoc lopHoc)
        {
          if (_context.LopHoc == null)
          {
              return Problem("Entity set 'AppDbContexts.LopHoc'  is null.");
          }
            _context.LopHoc.Add(lopHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLopHoc", new { id = lopHoc.Id }, lopHoc);
        }

        // DELETE: api/LopHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLopHoc(int id)
        {
            if (_context.LopHoc == null)
            {
                return NotFound();
            }
            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            _context.LopHoc.Remove(lopHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LopHocExists(int id)
        {
            return (_context.LopHoc?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
