using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _1ére_application_web_ASP.NET_CORE.Data;
using _1ére_application_web_ASP.NET_CORE.Models;
using Microsoft.AspNetCore.Authorization;

namespace _1ére_application_web_ASP.NET_CORE.Controllers
{
   
    public class etudiantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public etudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: etudiants
        public async Task<IActionResult> Index()
        {
            return View(await _context.etudiant.ToListAsync());
        }

        // GET: etudiants/Details/5
      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.etudiant
                .FirstOrDefaultAsync(m => m.id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }
        [Authorize(Roles = "User")]
        // GET: etudiants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: etudiants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nom,prenom,cin,adress,email,password")] etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            
            return View(etudiant);
        }

        [Authorize(Roles = "Admin")]
        // GET: etudiants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.etudiant.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            return View(etudiant);
        }

        // POST: etudiants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("id,nom,prenom,cin,adress,email,password")] etudiant etudiant)
        {
            if (id != etudiant.id)
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
                    if (!etudiantExists(etudiant.id))
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

        // GET: etudiants/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiant = await _context.etudiant
                .FirstOrDefaultAsync(m => m.id == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etudiant = await _context.etudiant.FindAsync(id);
            _context.etudiant.Remove(etudiant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool etudiantExists(int id)
        {
            return _context.etudiant.Any(e => e.id == id);
        }

        public  IActionResult login()
        {
            
           
            return View();
        }

    }
}
