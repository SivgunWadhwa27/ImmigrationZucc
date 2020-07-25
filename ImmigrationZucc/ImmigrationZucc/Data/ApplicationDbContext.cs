using ImmigrationZucc.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImmigrationZucc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Stream> Streams { get; set; }
        public DbSet<UserStreamSubscription> UserStreamSubscriptions { get; set; }
        public DbSet<WebhookEvent>  WebhookEvents { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
