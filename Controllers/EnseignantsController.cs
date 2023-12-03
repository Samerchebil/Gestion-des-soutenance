using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectFInalExam.Data;
using ProjectFInalExam.Models;

namespace ProjectFInalExam.Controllers
{
    public class EnseignantsController : Controller
    {
        private readonly PFEContext _context;

        public EnseignantsController(PFEContext context)
        {
            _context = context;
        }

        // GET: Enseignants
        public async Task<IActionResult> Index()
        {
              return _context.Enseignant != null ? 
                          View(await _context.Enseignant.ToListAsync()) :
                          Problem("Entity set 'PFEContext.Enseignant'  is null.");
        }

        // GET: Enseignants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enseignant == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // GET: Enseignants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enseignants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseignant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enseignant);
        }

        // GET: Enseignants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enseignant == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant.FindAsync(id);
            if (enseignant == null)
            {
                return NotFound();
            }
            return View(enseignant);
        }

        // POST: Enseignants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom")] Enseignant enseignant)
        {
            if (id != enseignant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseignant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignantExists(enseignant.Id))
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
            return View(enseignant);
        }

        // GET: Enseignants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enseignant == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // POST: Enseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enseignant == null)
            {
                return Problem("Entity set 'PFEContext.Enseignant'  is null.");
            }
            var enseignant = await _context.Enseignant.FindAsync(id);
            if (enseignant != null)
            {
                _context.Enseignant.Remove(enseignant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignantExists(int id)
        {
          return (_context.Enseignant?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
