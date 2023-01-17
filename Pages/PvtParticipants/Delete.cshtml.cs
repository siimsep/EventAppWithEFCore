using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventAppEFCore.Data;
using EventAppEFCore.Models;

namespace EventAppEFCore.Pages.PvtParticipants
{
    public class DeleteModel : PageModel
    {
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public DeleteModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PrivateParticipant PrivateParticipant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PrivateParticipant == null)
            {
                return NotFound();
            }

            var privateparticipant = await _context.PrivateParticipant.FirstOrDefaultAsync(m => m.ID == id);

            if (privateparticipant == null)
            {
                return NotFound();
            }
            else 
            {
                PrivateParticipant = privateparticipant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PrivateParticipant == null)
            {
                return NotFound();
            }
            var privateparticipant = await _context.PrivateParticipant.FindAsync(id);

            if (privateparticipant != null)
            {
                PrivateParticipant = privateparticipant;
                _context.PrivateParticipant.Remove(PrivateParticipant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
