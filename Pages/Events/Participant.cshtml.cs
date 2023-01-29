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
    public class ParticipantModel : PageModel
    {
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public ParticipantModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PrivateParticipant PrivateParticipant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EventInfo == null)
            {
                return NotFound();
            }

            var participantinfo = await _context.PrivateParticipant.FirstOrDefaultAsync(m => m.ID == id);
            if (participantinfo == null)
            {
                return NotFound();
            }
            PrivateParticipant = participantinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(PrivateParticipant.ToJson());

                return Page();
            }
            Console.WriteLine(PrivateParticipant.ToJson());

            _context.Attach(PrivateParticipant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(PrivateParticipant.ID))
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
            return _context.PrivateParticipant.Any(e => e.ID == id);
        }



    }
}
