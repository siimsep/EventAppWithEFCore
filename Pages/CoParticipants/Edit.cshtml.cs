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

namespace EventAppEFCore.Pages.CoParticipants
{
    public class EditModel : PageModel
    {
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public EditModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompanyParticipant CompanyParticipant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CompanyParticipant == null)
            {
                return NotFound();
            }

            var companyparticipant =  await _context.CompanyParticipant.FirstOrDefaultAsync(m => m.ID == id);
            if (companyparticipant == null)
            {
                return NotFound();
            }
            CompanyParticipant = companyparticipant;
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

            _context.Attach(CompanyParticipant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyParticipantExists(CompanyParticipant.ID))
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

        private bool CompanyParticipantExists(int id)
        {
          return _context.CompanyParticipant.Any(e => e.ID == id);
        }
    }
}
