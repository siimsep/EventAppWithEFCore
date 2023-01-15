using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventAppEFCore.Data;
using EventAppEFCore.Models;

namespace EventAppEFCore.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public DeleteModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EventInfo EventInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EventInfo == null)
            {
                return NotFound();
            }

            var eventinfo = await _context.EventInfo.FirstOrDefaultAsync(m => m.ID == id);

            if (eventinfo == null)
            {
                return NotFound();
            }
            else 
            {
                EventInfo = eventinfo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EventInfo == null)
            {
                return NotFound();
            }
            var eventinfo = await _context.EventInfo.FindAsync(id);

            if (eventinfo != null)
            {
                EventInfo = eventinfo;
                _context.EventInfo.Remove(EventInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
