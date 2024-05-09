using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
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
    public class ClientsController : Controller
    {
        private readonly ProjetFinal2050189Context _context;

        public ClientsController(ProjetFinal2050189Context context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
              return _context.Clients != null ? 
                          View(await _context.Clients.ToListAsync()) :
                          Problem("Entity set 'ProjetFinal2050189Context.Clients'  is null.");
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            Client? client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            string query = "EXEC VENTE.USP_RecupererNumClient @ClientID";

            SqlParameter parametres = new SqlParameter { ParameterName = "@ClientID", Value = id };

            List<ClientDechiffre> cd = await _context.ClientDechiffres.FromSqlRaw(query, parametres).ToListAsync();

            if (cd == null)
            {
                return NotFound();
            }

            ClientVM vm = new ClientVM()
            {
                Client = client,
                Dechiffre = cd[0]
            };





            

            return View(vm);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Prenom,NumeroTel")] InsertClientVM client)
        {
            bool exists = await _context.Clients.AnyAsync(x => x.Prenom ==  client.Prenom);
            if (exists)
            {
                ModelState.AddModelError("", "Already Exists");
                return View(client);
            }

            string query = "EXEC VENTE.USP_AjouterClient @Prenom,@NumeroTel";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter{ParameterName = "@Prenom", Value = client.Prenom},
                new SqlParameter{ParameterName = "@NumeroTel", Value = client.NumeroTel}
            };

            try
            {
                await _context.Database.ExecuteSqlRawAsync(query, parameters.ToArray());
            }
            catch
            {
                ModelState.AddModelError("", "ERROR");
                return View(client);
            }

            return RedirectToAction("Index");
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,Prenom,NumeroTel")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clients == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clients == null)
            {
                return Problem("Entity set 'ProjetFinal2050189Context.Clients'  is null.");
            }
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
          return (_context.Clients?.Any(e => e.ClientId == id)).GetValueOrDefault();
        }
    }
}
