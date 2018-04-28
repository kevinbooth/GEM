using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GEM.Models;

namespace GEM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event_User> Event_Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Event_Owner> Event_Owners { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Event_User>()
                .HasKey(c => new { c.Event, c.User });

            builder.Entity<Event_Owner>()
                .HasKey(c => new { c.Event, c.Owner });

            builder.Entity<Event>()
                .HasIndex(c => c.Id)
                .IsUnique();
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
