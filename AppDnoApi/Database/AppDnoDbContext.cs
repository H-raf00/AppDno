using AppDnoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Database
{
    public class AppDnoDbContext : DbContext
    {
        public AppDnoDbContext(DbContextOptions<AppDnoDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Vérifie si une configuration est déjà présente
            if (!options.IsConfigured)
            {
                // Connexion à PostgreSQL par défaut (pour design-time/migrations)
                options.UseNpgsql("Host=localhost;Database=mydatabase;Username=postgres;Password=postgrespw");
            }
        }

        // All DbSets in one place
        public DbSet<User> Users { get; set; } = null!;
        //public DbSet<Ingredient> Ingredients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}