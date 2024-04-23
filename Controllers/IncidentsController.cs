using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kald_IntsiHaldur.Data;
using Kald_IntsiHaldur.Models;
using Microsoft.Identity.Client;

namespace Kald_IntsiHaldur.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly Kald_IntsiHaldurContext _context;

        public IncidentsController(Kald_IntsiHaldurContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            //Enne kui saadame nad vaatele renderdamiseks, järjestame nad lahendamise tähtaja järgi kahenevas järjekorras 
            var incidents = from i in _context.Incident select i;
            incidents = incidents.OrderByDescending(i => i.DateTimeDeadline);
            return View(await incidents.AsNoTracking().ToListAsync());
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(string descriptionfield, DateTime datetimepick)
        {
            Guid guid = Guid.NewGuid();
            var incident = new Incident
            {
                Id = Guid.NewGuid(),
                Description = descriptionfield,
                DateTimeCreated = DateTime.Now,
                DateTimeDeadline = datetimepick
            };
            _context.Add(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST päringu abil saame Guid formaadis ID, mida pärast teisendamist 
        public async Task<IActionResult> MarkDone(Guid incidentID)
        {
            Console.WriteLine("ID:" + incidentID.ToString());
            //Otsime andmebaasist õige pöördumise, mille ID vastaks incidentID-le
            var incident = await _context.Incident.FindAsync(incidentID);
            if (incident != null)
            {
                _context.Incident.Remove(incident); //Eemaldame pöördumise
            }

            await _context.SaveChangesAsync(); //Salvestame andmebaasi
            return RedirectToAction(nameof(Index)); //Naaseme index lehele
        }

        private bool IncidentExists(Guid id)
        {
            return _context.Incident.Any(e => e.Id == id);
        }
    }
}
