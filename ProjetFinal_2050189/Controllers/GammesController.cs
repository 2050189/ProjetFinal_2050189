using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using ProjetFinal_2050189.Data;
using ProjetFinal_2050189.Models;
using ProjetFinal_2050189.ViewModels;

namespace ProjetFinal_2050189.Controllers
{
    public class GammesController : Controller
    {
        private readonly ProjetFinal2050189Context _context;

        public GammesController(ProjetFinal2050189Context context)
        {
            _context = context;
        }

        // GET: Gammes
        public async Task<IActionResult> Index()
        {
            if(_context.Gammes== null)
            {
                return Problem();
            }

            List<GammePhotoVM> gpvm = await _context.Gammes.Select(x => new GammePhotoVM
            {
                Gamme = x,
                ImgUrl = x.Photo == null ? null : $"data:image/png;base64, {Convert.ToBase64String(x.Photo)}"
            }).ToListAsync();

            return View(gpvm);
        }

        // GET: Gammes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gammes == null)
            {
                return NotFound();
            }

            var gamme = await _context.Gammes
                .FirstOrDefaultAsync(m => m.GammeId == id);
            if (gamme == null)
            {
                return NotFound();
            }

            return View(gamme);
        }

        // GET: Gammes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gammes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GammeId,Nom,AnneeSortie,Cote,Note1,Note2,Note3,Couleur,Identifiant,Photo")] Gamme gamme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gamme);
        }

        // GET: Gammes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gammes == null)
            {
                return NotFound();
            }

            var gamme = await _context.Gammes.FindAsync(id);
            if (gamme == null)
            {
                return NotFound();
            }

            UploadPhotoGammeVM uploadPhotoGammeVM = new UploadPhotoGammeVM();

            uploadPhotoGammeVM.GammeID = gamme.GammeId;

            return View(uploadPhotoGammeVM);
        }

        // POST: Gammes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UploadPhotoGammeVM vm)
        {
            Gamme gamme = await _context.Gammes.FindAsync(vm.GammeID);


            if (ModelState.IsValid)
            {
                
                try
                {
                    if (vm.FormFile != null && vm.FormFile.Length >= 0)
                    {
                        MemoryStream stream = new MemoryStream();
                        await vm.FormFile.CopyToAsync(stream);
                        byte[] photo = stream.ToArray();
                        gamme.Photo = photo;
                    }
                    _context.Update(gamme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GammeExists(gamme.GammeId))
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
            return View(gamme);
        }

        // GET: Gammes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gammes == null)
            {
                return NotFound();
            }

            var gamme = await _context.Gammes
                .FirstOrDefaultAsync(m => m.GammeId == id);
            if (gamme == null)
            {
                return NotFound();
            }

            return View(gamme);
        }

        // POST: Gammes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gammes == null)
            {
                return Problem("Entity set 'ProjetFinal2050189Context.Gammes'  is null.");
            }
            var gamme = await _context.Gammes.FindAsync(id);
            if (gamme != null)
            {
                _context.Gammes.Remove(gamme);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GammeExists(int id)
        {
          return (_context.Gammes?.Any(e => e.GammeId == id)).GetValueOrDefault();
        }
    }
}
