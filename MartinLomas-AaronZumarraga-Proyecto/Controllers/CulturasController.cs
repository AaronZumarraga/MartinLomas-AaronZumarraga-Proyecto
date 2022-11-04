﻿using System;
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
    public class CulturasController : Controller
    {
        private readonly MartinLomas_AaronZumarraga_ProyectoContext _context;

        public CulturasController(MartinLomas_AaronZumarraga_ProyectoContext context)
        {
            _context = context;
        }

        // GET: Culturas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cultura.ToListAsync());
        }

        // GET: Culturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cultura == null)
            {
                return NotFound();
            }

            var cultura = await _context.Cultura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cultura == null)
            {
                return NotFound();
            }

            return View(cultura);
        }

        // GET: Culturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Culturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Asunto,Discusion,Fecha")] Cultura cultura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cultura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cultura);
        }

        // GET: Culturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cultura == null)
            {
                return NotFound();
            }

            var cultura = await _context.Cultura.FindAsync(id);
            if (cultura == null)
            {
                return NotFound();
            }
            return View(cultura);
        }

        // POST: Culturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Asunto,Discusion,Fecha")] Cultura cultura)
        {
            if (id != cultura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cultura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CulturaExists(cultura.Id))
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
            return View(cultura);
        }

        // GET: Culturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cultura == null)
            {
                return NotFound();
            }

            var cultura = await _context.Cultura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cultura == null)
            {
                return NotFound();
            }

            return View(cultura);
        }

        // POST: Culturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cultura == null)
            {
                return Problem("Entity set 'MartinLomas_AaronZumarraga_ProyectoContext.Cultura'  is null.");
            }
            var cultura = await _context.Cultura.FindAsync(id);
            if (cultura != null)
            {
                _context.Cultura.Remove(cultura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CulturaExists(int id)
        {
          return _context.Cultura.Any(e => e.Id == id);
        }
    }
}
