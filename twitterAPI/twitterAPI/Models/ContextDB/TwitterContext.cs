using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace twitterAPI.Models.ContextDB
{
    public class TwitterContext : DbContext
    {
        public TwitterContext(DbContextOptions<TwitterContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserID = -1,
                Name = "admin",
                Password = "admin123",
                Email = "admin@email.com",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow
            }
        );
        }

        public DbSet<Tweet> Twitter { get; set; }
        public DbSet<User> User { get; set; }
    }
}
