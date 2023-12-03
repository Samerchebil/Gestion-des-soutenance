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
    public class PFE_ETUDIANTController : Controller
    {
        private readonly PFEContext _context;

        public PFE_ETUDIANTController(PFEContext context)
        {
            _context = context;
        }

        // GET: PFE_ETUDIANT
        public async Task<IActionResult> Index()
        {
            var pFEContext = _context.PFE_ETUDIANT.Include(p => p.Etudiant).Include(p => p.PFE);
            return View(await pFEContext.ToListAsync());
        }

        // GET: PFE_ETUDIANT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PFE_ETUDIANT == null)
            {
                return NotFound();
            }

            var pFE_ETUDIANT = await _context.PFE_ETUDIANT
                .Include(p => p.Etudiant)
                .Include(p => p.PFE)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pFE_ETUDIANT == null)
            {
                return NotFound();
            }

            return View(pFE_ETUDIANT);
        }

        // GET: PFE_ETUDIANT/Create
        public IActionResult Create()
        {
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Nom");
            ViewData["PFEID"] = new SelectList(_context.PFE, "Id", "Titre");
            return View();
        }

        // POST: PFE_ETUDIANT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PFEID,EtudiantId")] PFE_ETUDIANT pFE_ETUDIANT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pFE_ETUDIANT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Nom", pFE_ETUDIANT.EtudiantId);
            ViewData["PFEID"] = new SelectList(_context.PFE, "Id", "Titre", pFE_ETUDIANT.PFEID);
            return View(pFE_ETUDIANT);
        }

        // GET: PFE_ETUDIANT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PFE_ETUDIANT == null)
            {
                return NotFound();
            }

            var pFE_ETUDIANT = await _context.PFE_ETUDIANT.FindAsync(id);
            if (pFE_ETUDIANT == null)
            {
                return NotFound();
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Nom", pFE_ETUDIANT.EtudiantId);
            ViewData["PFEID"] = new SelectList(_context.PFE, "Id", "Titre", pFE_ETUDIANT.PFEID);
            return View(pFE_ETUDIANT);
        }

        // POST: PFE_ETUDIANT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PFEID,EtudiantId")] PFE_ETUDIANT pFE_ETUDIANT)
        {
            if (id != pFE_ETUDIANT.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pFE_ETUDIANT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PFE_ETUDIANTExists(pFE_ETUDIANT.Id))
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
            ViewData["EtudiantId"] = new SelectList(_context.Etudiants, "Id", "Nom", pFE_ETUDIANT.EtudiantId);
            ViewData["PFEID"] = new SelectList(_context.PFE, "Id", "Titre", pFE_ETUDIANT.PFEID);
            return View(pFE_ETUDIANT);
        }

        // GET: PFE_ETUDIANT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PFE_ETUDIANT == null)
            {
                return NotFound();
            }

            var pFE_ETUDIANT = await _context.PFE_ETUDIANT
                .Include(p => p.Etudiant)
                .Include(p => p.PFE)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pFE_ETUDIANT == null)
            {
                return NotFound();
            }

            return View(pFE_ETUDIANT);
        }

        // POST: PFE_ETUDIANT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PFE_ETUDIANT == null)
            {
                return Problem("Entity set 'PFEContext.PFE_ETUDIANT'  is null.");
            }
            var pFE_ETUDIANT = await _context.PFE_ETUDIANT.FindAsync(id);
            if (pFE_ETUDIANT != null)
            {
                _context.PFE_ETUDIANT.Remove(pFE_ETUDIANT);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PFE_ETUDIANTExists(int id)
        {
          return (_context.PFE_ETUDIANT?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
