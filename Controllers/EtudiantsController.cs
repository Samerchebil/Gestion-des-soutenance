using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectFInalExam.Data;
using ProjectFInalExam.Models;
using PagedList;

namespace ProjectFInalExam.Controllers
{
    public class EtudiantsController : Controller
    {
        private readonly PFEContext _context;

        public EtudiantsController(PFEContext context)
        {
            _context = context;
        }

        // GET: Etudiants
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("Nom") ? "name_desc" : "";
            ViewBag.PreNameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("Prenom") ? "pre_name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var etudiants = from e in _context.Etudiants
                            select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                etudiants = etudiants.Where(e => e.Nom.Contains(searchString)
                                           || e.Prenom.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    etudiants = etudiants.OrderByDescending(e => e.Nom);
                    break;
                case "pre_name_desc":
                    etudiants = etudiants.OrderByDescending(e => e.Prenom);
                    break;
                case "Date":
                    etudiants = etudiants.OrderBy(e => e.DateN);
                    break;
                case "date_desc":
                    etudiants = etudiants.OrderByDescending(e => e.DateN);
                    break;
                default:
                    etudiants = etudiants.OrderBy(e => e.Nom);
                    break;
            }

            return  View(await etudiants.ToListAsync());

        }


        //public async Task<IActionResult> Index(string searchString, string currentFilter, string sortOrder, int? page)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("Nom") ? "name_desc" : "";
        //    ViewBag.PreNameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("Prenom") ? "pre_name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    ViewBag.CurrentFilter = searchString;

        //    var etudiants = from e in _context.Etudiants
        //                    select e;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        etudiants = etudiants.Where(e => e.Nom.Contains(searchString)
        //                                   || e.Prenom.Contains(searchString));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            etudiants = etudiants.OrderByDescending(e => e.Nom);
        //            break;
        //        case "pre_name_desc":
        //            etudiants = etudiants.OrderByDescending(e => e.Prenom);
        //            break;
        //        case "Date":
        //            etudiants = etudiants.OrderBy(e => e.DateN);
        //            break;
        //        case "date_desc":
        //            etudiants = etudiants.OrderByDescending(e => e.DateN);
        //            break;
        //        default:
        //            etudiants = etudiants.OrderBy(e => e.Nom);
        //            break;
        //    }

        //    int pageSize = 3;
        //    int pageNumber = (page ?? 1);
        //    return View(etudiants.ToPagedList(pageNumber, pageSize));
        //}

        // GET: Etudiants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // GET: Etudiants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,DateN")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,DateN")] Etudiant etudiant)
        {
            if (id != etudiant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.Id))
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
            return View(etudiant);
        }

        // GET: Etudiants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Etudiants == null)
            {
                return Problem("Entity set 'PFEContext.Etudiants'  is null.");
            }
            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant != null)
            {
                _context.Etudiants.Remove(etudiant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
          return (_context.Etudiants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
