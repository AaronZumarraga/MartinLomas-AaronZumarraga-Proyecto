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
    public class TecnologiasController : Controller
    {
        private readonly MartinLomas_AaronZumarraga_ProyectoContext _context;

        public TecnologiasController(MartinLomas_AaronZumarraga_ProyectoContext context)
        {
            _context = context;
        }

        // GET: Tecnologias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tecnologia.ToListAsync());
        }

        // GET: Tecnologias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tecnologia == null)
            {
                return NotFound();
            }

            var tecnologia = await _context.Tecnologia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologia == null)
            {
                return NotFound();
            }

            return View(tecnologia);
        }

        // GET: Tecnologias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnologias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Asunto,Discusion,Fecha")] Tecnologia tecnologia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnologia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnologia);
        }

        // GET: Tecnologias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tecnologia == null)
            {
                return NotFound();
            }

            var tecnologia = await _context.Tecnologia.FindAsync(id);
            if (tecnologia == null)
            {
                return NotFound();
            }
            return View(tecnologia);
        }

        // POST: Tecnologias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Asunto,Discusion,Fecha")] Tecnologia tecnologia)
        {
            if (id != tecnologia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnologia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnologiaExists(tecnologia.Id))
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
            return View(tecnologia);
        }

        // GET: Tecnologias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tecnologia == null)
            {
                return NotFound();
            }

            var tecnologia = await _context.Tecnologia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologia == null)
            {
                return NotFound();
            }

            return View(tecnologia);
        }

        // POST: Tecnologias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tecnologia == null)
            {
                return Problem("Entity set 'MartinLomas_AaronZumarraga_ProyectoContext.Tecnologia'  is null.");
            }
            var tecnologia = await _context.Tecnologia.FindAsync(id);
            if (tecnologia != null)
            {
                _context.Tecnologia.Remove(tecnologia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnologiaExists(int id)
        {
          return _context.Tecnologia.Any(e => e.Id == id);
        }
    }
}
