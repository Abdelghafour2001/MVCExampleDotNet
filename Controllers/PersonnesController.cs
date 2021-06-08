using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Migrations;

namespace MVC.Controllers
{
    public class PersonnesController : Controller
    {
        //private readonly ApplicationDbContext _context;
       private ApplicationDbContext context = new ApplicationDbContext();
    /*    public PersonnesController(ApplicationDbContext context)
        {
            _context = context;
        }*/

        // GET: Personnes
        public IActionResult Index()
        {
            List<Personne> personnes = new List<Personne>();
            
                var query = from p in context.Personnes
                            select p;

                foreach (var p in query)
                {
                    personnes.Add(p);
                }
            
            return View(personnes);
        }

        // GET: Personnes/Details/5
       public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await context.Personnes
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

       // GET: Personnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personnes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adresse,Age,Nom")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                context.Add(personne);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personne);
        }

        // GET: Personnes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await context.Personnes.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }
            return View(personne);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Adresse,Age,Nom")] Personne personne)
        {
            if (id != personne.Nom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(personne);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneExists(personne.Nom))
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
            return View(personne);
        }

        // GET: Personnes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await context.Personnes
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // POST: Personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personne = await context.Personnes.FindAsync(id);
            context.Personnes.Remove(personne);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonneExists(string id)
        {
            return context.Personnes.Any(e => e.Nom == id);
        }
    }
}
