using AppDnoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDnoApi.Database
{
    public class AppDnoDbContext : DbContext
    {
        public AppDnoDbContext(DbContextOptions<AppDnoDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql("Host=localhost;Database=mydatabase;Username=postgres;Password=postgrespw");
            }
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Indicator> Indicators { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            // Ajoutez un index unique sur Email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Name)
                .IsUnique();
            
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Responsable)
                .WithMany()
                .HasForeignKey(p => p.ResponsableId)
                .OnDelete(DeleteBehavior.SetNull);
            //.OnDelete(DeleteBehavior.Restrict); // Should the Project be deleted if the Responsable is deleted? 

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Users)
                .WithMany(u => u.Projets)
                .UsingEntity(j => j.ToTable("ProjectUsers"));
            
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Projets)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.SetNull);
            //.OnDelete(DeleteBehavior.Restrict); // Should the Project be deleted if the Client is deleted? Or should the ClientId just be set to null?

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Ingredients)
                .WithMany(i => i.Projects)
                .UsingEntity(j => j.ToTable("ProjectIngredients"));

            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Supplier)
                .WithMany(s => s.Ingredients)
                .HasForeignKey(i => i.SupplierId)
                .OnDelete(DeleteBehavior.SetNull); // If the supplier is deleted, set the SupplierId to null

            modelBuilder.Entity<Ingredient>()
                .HasIndex(i => i.Name)
                .IsUnique();
            
            modelBuilder.Entity<Supplier>()
                .HasIndex(s => s.Name)
                .IsUnique();
            
            modelBuilder.Entity<Indicator>()
                .HasIndex(i => i.Name)
                .IsUnique();
        }
    }
}