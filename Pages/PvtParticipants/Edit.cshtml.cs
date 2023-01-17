using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventAppEFCore.Data;
using EventAppEFCore.Models;

namespace EventAppEFCore.Pages.PvtParticipants
{
    public class EditModel : PageModel
    {
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public EditModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PrivateParticipant PrivateParticipant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PrivateParticipant == null)
            {
                return NotFound();
            }

            var privateparticipant =  await _context.PrivateParticipant.FirstOrDefaultAsync(m => m.ID == id);
            if (privateparticipant == null)
            {
                return NotFound();
            }
            PrivateParticipant = privateparticipant;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PrivateParticipant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateParticipantExists(PrivateParticipant.ID))
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

        private bool PrivateParticipantExists(int id)
        {
          return _context.PrivateParticipant.Any(e => e.ID == id);
        }
    }
}
