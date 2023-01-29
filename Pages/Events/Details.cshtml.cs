using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EventAppEFCore.Data;
using EventAppEFCore.Models;
using NuGet.Protocol;
using NuGet.Packaging;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EventAppEFCore.Pages.Events
{
    public class DetailsModel : PageModel
    {
        // Entity Framework Core context
        private readonly EventAppEFCore.Data.EventAppEFCoreContext _context;

        public DetailsModel(EventAppEFCore.Data.EventAppEFCoreContext context)
        {
            _context = context;
        }
        // Getting events info from EF 
        public EventInfo EventInfo { get; set; }
        // evid  (short for event id) is variable to store the Id got from OnGetAsync method. This is passed in with participants information as a foreign key relation to an event. If it works it aint stupid.
        private static int evid;
        // List of participants
        //public IList<PrivateParticipant> PrivateParticipants { get; set; }
        //public IList<CompanyParticipant> CompanyParticipants { get; set; }
        public IList<Participant> Participants { get; set; } = new List<Participant>();

        // In the following might be nicer to use the Id saved earlier
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
                evid = EventInfo.ID;
                Participants.AddRange(_context.PrivateParticipant.Where(x => x.EventInfoId == evid).ToList());
                Participants.AddRange(_context.CompanyParticipant.Where(x => x.EventInfoId == evid).ToList());
            }
            return Page();
        }



        // Company participant form submitting

        public CompanyParticipant CompanyParticipant { get; set; } = new CompanyParticipant();
        public async Task<IActionResult> OnPostCoAsync(CompanyParticipant CompanyParticipant )
        {
            if (!ModelState.IsValid)
            {

                return await OnGetAsync(id: evid);
            }
            CompanyParticipant.EventInfoId = evid;
            _context.CompanyParticipant.Add(CompanyParticipant);
            await _context.SaveChangesAsync();
            return Redirect($"/Events/Details?id={evid}");
        }



        // Private participant form submitting

        public PrivateParticipant PrivateParticipant { get; set; } = new PrivateParticipant();
        public async Task<IActionResult> OnPostPvtAsync(PrivateParticipant PrivateParticipant)
        {
            
            if (!ModelState.IsValid)
            {
                return await OnGetAsync(id: evid);
            }
            PrivateParticipant.EventInfoId = evid;
            // for debugging purposes
            //Console.WriteLine(PrivateParticipant.ToJson());
            _context.PrivateParticipant.Add(PrivateParticipant);
            await _context.SaveChangesAsync();
            return Redirect($"/Events/Details?id={evid}");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int? id)
        {
            if (id == null || _context.PrivateParticipant == null)
            {
                Console.WriteLine("not found?");

                return NotFound();
            }
            var participant = await _context.PrivateParticipant.FindAsync(id);

            if (participant != null)
            {

                _context.PrivateParticipant.Remove(participant);
                await _context.SaveChangesAsync();
            }
            Console.WriteLine("deleted");
            return Redirect($"/Events/Details?id={evid}");
        }
        public async Task<IActionResult> OnPostDeleteCoAsync(int? id)
        {
            if (id == null || _context.CompanyParticipant == null)
            {
                Console.WriteLine("not found?");

                return NotFound();
            }
            var participant = await _context.CompanyParticipant.FindAsync(id);

            if (participant != null)
            {

                _context.CompanyParticipant.Remove(participant);
                await _context.SaveChangesAsync();
            }
            Console.WriteLine("deleted");
            return Redirect($"/Events/Details?id={evid}");
        }
    }

    }
