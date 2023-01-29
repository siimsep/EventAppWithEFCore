using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EventAppEFCore.Data;
using EventAppEFCore.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace EventAppEFCore.Pages.Events
{
    public class CoParticipantModel : PageModel
    {
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public CoParticipantModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompanyParticipant CompanyParticipant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EventInfo == null)
            {
                return NotFound();
            }

            var participantinfo = await _context.CompanyParticipant.FirstOrDefaultAsync(m => m.ID == id);
            if (participantinfo == null)
            {
                return NotFound();
            }
            CompanyParticipant = participantinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(CompanyParticipant.ToJson());

                return Page();
            }
            Console.WriteLine(CompanyParticipant.ToJson());

            _context.Attach(CompanyParticipant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(CompanyParticipant.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ParticipantExists(int id)
        {
            return _context.CompanyParticipant.Any(e => e.ID == id);
        }



    }
}
