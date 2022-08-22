using Domain.Gebruikers;
using Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Configuration;

namespace Persistence.Data
{
    public class FaithDbContext : DbContext
    {
        public FaithDbContext(DbContextOptions<FaithDbContext> options)
        : base(options)
        {
        }

        public DbSet<Jongere> Jongeren { get; set; }
        public DbSet<Begeleider> Begeleiders { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reactie> Reactie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PostEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ReactieEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new JongereEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BegeleiderEntityTypeConfiguration());
        }
    }
}
