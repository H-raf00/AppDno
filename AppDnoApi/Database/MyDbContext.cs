using AppDnoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

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

            // Exemple de configuration de relations (décommentez selon vos besoins)
            /*
            modelBuilder.Entity<Progression>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            */
        }
    }
}