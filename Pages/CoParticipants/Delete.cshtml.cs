using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventAppEFCore.Data;
using EventAppEFCore.Models;

namespace EventAppEFCore.Pages.CoParticipants
{
    public class DeleteModel : PageModel
    {
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public DeleteModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CompanyParticipant CompanyParticipant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CompanyParticipant == null)
            {
                return NotFound();
            }

            var companyparticipant = await _context.CompanyParticipant.FirstOrDefaultAsync(m => m.ID == id);

            if (companyparticipant == null)
            {
                return NotFound();
            }
            else 
            {
                CompanyParticipant = companyparticipant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CompanyParticipant == null)
            {
                return NotFound();
            }
            var companyparticipant = await _context.CompanyParticipant.FindAsync(id);

            if (companyparticipant != null)
            {
                CompanyParticipant = companyparticipant;
                _context.CompanyParticipant.Remove(CompanyParticipant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
