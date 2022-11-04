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
    public class DeportesController : Controller
    {
        private readonly MartinLomas_AaronZumarraga_ProyectoContext _context;

        public DeportesController(MartinLomas_AaronZumarraga_ProyectoContext context)
        {
            _context = context;
        }

        // GET: Deportes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Deporte.ToListAsync());
        }

        // GET: Deportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deporte == null)
            {
                return NotFound();
            }

            var deporte = await _context.Deporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deporte == null)
            {
                return NotFound();
            }

            return View(deporte);
        }

        // GET: Deportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Asunto,Discusion,Fecha")] Deporte deporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deporte);
        }

        // GET: Deportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deporte == null)
            {
                return NotFound();
            }

            var deporte = await _context.Deporte.FindAsync(id);
            if (deporte == null)
            {
                return NotFound();
            }
            return View(deporte);
        }

        // POST: Deportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Asunto,Discusion,Fecha")] Deporte deporte)
        {
            if (id != deporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeporteExists(deporte.Id))
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
            return View(deporte);
        }

        // GET: Deportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deporte == null)
            {
                return NotFound();
            }

            var deporte = await _context.Deporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deporte == null)
            {
                return NotFound();
            }

            return View(deporte);
        }

        // POST: Deportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deporte == null)
            {
                return Problem("Entity set 'MartinLomas_AaronZumarraga_ProyectoContext.Deporte'  is null.");
            }
            var deporte = await _context.Deporte.FindAsync(id);
            if (deporte != null)
            {
                _context.Deporte.Remove(deporte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeporteExists(int id)
        {
          return _context.Deporte.Any(e => e.Id == id);
        }
    }
}
