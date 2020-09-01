using ImmigrationZucc.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace ImmigrationZucc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Stream> Streams { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<UserStreamSubscription> UserStreamSubscriptions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<WebhookEvent>  WebhookEvents { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
