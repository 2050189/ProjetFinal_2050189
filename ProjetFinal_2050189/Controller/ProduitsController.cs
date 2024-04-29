﻿using System;
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
    public class ProduitsController : Controller
    {
        private readonly ProjetFinal2050189Context _context;

        public ProduitsController(ProjetFinal2050189Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProduitsVendusEtNombreVendusMagasin(int magasinID)
        {
            Magasin? magasin = await _context.Magasins.FindAsync(magasinID);

            if(magasin == null)
            {
                return NotFound("MAGASIN INTROUVABLE");
            }

            string query = "EXEC VENTE.usp_ProduitsVendusEtNombreVendusMagasin @MagasinID";

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter{ParameterName = "@MagasinID", Value = magasin.MagasinId }
            };

            return View("ProduitsVendusEtNombreVendusMagasin", new MagasinInfoVM()
            {
                Magasin = magasin,
                ProduitVenduParMagasin = (IEnumerable<Produit>)await _context.Magasins.FromSqlRaw(query, param.ToArray()).ToListAsync()
            });
        }

        public async Task<IActionResult> VueTypeProduit()
        {
            List<VwTypeDesProduit> vue = await _context.VwTypeDesProduits.ToListAsync();
            return View(vue);
        }

        // GET: Produits
        public async Task<IActionResult> Index()
        {
            var projetFinal2050189Context = _context.Produits.Include(p => p.Gamme);
            return View(await projetFinal2050189Context.ToListAsync());
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .Include(p => p.Gamme)
                .FirstOrDefaultAsync(m => m.ProduitId == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // GET: Produits/Create
        public IActionResult Create()
        {
            ViewData["GammeId"] = new SelectList(_context.Gammes, "GammeId", "GammeId");
            return View();
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProduitId,Nom,Format,GammeId")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GammeId"] = new SelectList(_context.Gammes, "GammeId", "GammeId", produit.GammeId);
            return View(produit);
        }

        // GET: Produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            ViewData["GammeId"] = new SelectList(_context.Gammes, "GammeId", "GammeId", produit.GammeId);
            return View(produit);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProduitId,Nom,Format,GammeId")] Produit produit)
        {
            if (id != produit.ProduitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduitExists(produit.ProduitId))
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
            ViewData["GammeId"] = new SelectList(_context.Gammes, "GammeId", "GammeId", produit.GammeId);
            return View(produit);
        }

        // GET: Produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits
                .Include(p => p.Gamme)
                .FirstOrDefaultAsync(m => m.ProduitId == id);
            if (produit == null)
            {
                return NotFound();
            }

            return View(produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produits == null)
            {
                return Problem("Entity set 'ProjetFinal2050189Context.Produits'  is null.");
            }
            var produit = await _context.Produits.FindAsync(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitExists(int id)
        {
          return (_context.Produits?.Any(e => e.ProduitId == id)).GetValueOrDefault();
        }
    }
}
