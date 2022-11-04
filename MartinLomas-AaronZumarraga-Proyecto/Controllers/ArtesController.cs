using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MartinLomas_AaronZumarraga_Proyecto.Data;
using MartinLomas_AaronZumarraga_Proyecto.Models;

namespace MartinLomas_AaronZumarraga_Proyecto.Controllers
{
    public class ArtesController : Controller
    {
        private readonly MartinLomas_AaronZumarraga_ProyectoContext _context;

        public ArtesController(MartinLomas_AaronZumarraga_ProyectoContext context)
        {
            _context = context;
        }

        // GET: Artes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Arte.ToListAsync());
        }

        // GET: Artes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Arte == null)
            {
                return NotFound();
            }

            var arte = await _context.Arte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arte == null)
            {
                return NotFound();
            }

            return View(arte);
        }

        // GET: Artes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Asunto,Discusion,Fecha")] Arte arte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arte);
        }

        // GET: Artes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Arte == null)
            {
                return NotFound();
            }

            var arte = await _context.Arte.FindAsync(id);
            if (arte == null)
            {
                return NotFound();
            }
            return View(arte);
        }

        // POST: Artes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Asunto,Discusion,Fecha")] Arte arte)
        {
            if (id != arte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArteExists(arte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(arte);
        }

        // GET: Artes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Arte == null)
            {
                return NotFound();
            }

            var arte = await _context.Arte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arte == null)
            {
                return NotFound();
            }

            return View(arte);
        }

        // POST: Artes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Arte == null)
            {
                return Problem("Entity set 'MartinLomas_AaronZumarraga_ProyectoContext.Arte'  is null.");
            }
            var arte = await _context.Arte.FindAsync(id);
            if (arte != null)
            {
                _context.Arte.Remove(arte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArteExists(int id)
        {
          return _context.Arte.Any(e => e.Id == id);
        }
    }
}
