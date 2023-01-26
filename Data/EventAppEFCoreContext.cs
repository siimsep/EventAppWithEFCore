using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventAppEFCore.Models;

namespace EventAppEFCore.Data
{
    public class EventAppEFCoreContext : DbContext
    {
        public EventAppEFCoreContext (DbContextOptions<EventAppEFCoreContext> options)
            : base(options)
        {
        }

        public DbSet<EventInfo> EventInfo { get; set; } = default!;

        public DbSet<PrivateParticipant> PrivateParticipant { get; set; } = default!;

        public DbSet<CompanyParticipant> CompanyParticipant { get; set; } = default!;
    }
}
