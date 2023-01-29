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
    public class IndexModel : PageModel
    {
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public IndexModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }

        public IList<EventInfo> EventInfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EventInfo != null)
            {
                EventInfo = await _context.EventInfo.ToListAsync();
            }
        }
        
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null || _context.EventInfo == null)
            {
                Console.WriteLine("not found?");

                return NotFound();
            }
            var eventinfo = await _context.EventInfo.FindAsync(id);

            if (eventinfo != null)
            {

                _context.EventInfo.Remove(eventinfo);
                await _context.SaveChangesAsync();
            }
            Console.WriteLine("deleted");
            return RedirectToPage("./Index");
        }
    }
}
