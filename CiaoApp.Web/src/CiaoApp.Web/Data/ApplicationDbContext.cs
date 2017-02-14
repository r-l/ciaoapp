using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CiaoApp.Web.Models;
using CiaoApp.Web.Models.Actors;
using CiaoApp.Web.Models.Promises;
using CiaoApp.Web.Models.Contacts;
using CiaoApp.Web.Models.Notifications;
using CiaoApp.Web.Models.Messages;
using CiaoApp.Web.Models.Promises.Associations;

namespace CiaoApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Actor> Actor { get; set; }

        public DbSet<Promise> Promise { get; set; }

        public DbSet<Offer> Offer { get; set; }

        public DbSet<PromiseState> State { get; set; }

        public DbSet<Association> Association { get; set; }

        public DbSet<Contact> Contact { get; set; }

        public DbSet<ContactGroup> ContactGroup { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet<Notification> Notification { get; set; }

        public DbSet<Message> Message { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
