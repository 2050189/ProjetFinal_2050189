using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_2050189.Data;
using ProjetFinal_2050189.Models;
using ProjetFinal_2050189.ViewModels;

namespace ProjetFinal_2050189.Controllers
{
    public class MagasinsController : Controller
    {
        private readonly ProjetFinal2050189Context _context;

        public MagasinsController(ProjetFinal2050189Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProduitsVendusEtNombreVendusMagasin(int id)
        {
            Magasin? magasin = await _context.Magasins.FindAsync(id);
            string query = "EXEC VENTE.usp_ProduitsVendusEtNombreVendusMagasin @MagasinID";

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter{ParameterName = "@MagasinID", Value = id }
            };

            List<VwMagasinVenteInfo> infos = await _context.VwMagasinVenteInfos.FromSqlRaw(query, param.ToArray()).ToListAsync();

            if (infos == null)
            {
                return NotFound("MAGASIN INTROUVABLE");
            }



            return View("ProduitsVendusEtNombreVendusMagasin", new MagasinInfoVM()
            {
                Magasin = magasin,
                Infos = infos

            }) ;
        }

        // GET: Magasins
        public async Task<IActionResult> Index()
        {
              return _context.Magasins != null ? 
                          View(await _context.Magasins.ToListAsync()) :
                          Problem("Entity set 'ProjetFinal2050189Context.Magasins'  is null.");
        }

        // GET: Magasins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Magasins == null)
            {
                return NotFound();
            }

            var magasin = await _context.Magasins
                .FirstOrDefaultAsync(m => m.MagasinId == id);
            if (magasin == null)
            {
                return NotFound();
            }

            return View(magasin);
        }

        // GET: Magasins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magasins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MagasinId,Nom,AprogrammePts")] Magasin magasin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magasin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(magasin);
        }

        // GET: Magasins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Magasins == null)
            {
                return NotFound();
            }

            var magasin = await _context.Magasins.FindAsync(id);
            if (magasin == null)
            {
                return NotFound();
            }
            return View(magasin);
        }

        // POST: Magasins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MagasinId,Nom,AprogrammePts")] Magasin magasin)
        {
            if (id != magasin.MagasinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(magasin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagasinExists(magasin.MagasinId))
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
            return View(magasin);
        }

        // GET: Magasins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Magasins == null)
            {
                return NotFound();
            }

            var magasin = await _context.Magasins
                .FirstOrDefaultAsync(m => m.MagasinId == id);
            if (magasin == null)
            {
                return NotFound();
            }

            return View(magasin);
        }

        // POST: Magasins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Magasins == null)
            {
                return Problem("Entity set 'ProjetFinal2050189Context.Magasins'  is null.");
            }
            var magasin = await _context.Magasins.FindAsync(id);
            if (magasin != null)
            {
                _context.Magasins.Remove(magasin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MagasinExists(int id)
        {
          return (_context.Magasins?.Any(e => e.MagasinId == id)).GetValueOrDefault();
        }
    }
}
