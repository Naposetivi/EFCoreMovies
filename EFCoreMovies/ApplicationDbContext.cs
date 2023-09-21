using EFCoreMovies.Entities;
using EFCoreMovies.Entities.Functions;
using EFCoreMovies.Entities.Keyless;
using EFCoreMovies.Entities.Seeding;
using EFCoreMovies.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFCoreMovies
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options/*, IChangeTrackerEventHandler changeTrackerEventHandler*/) : base(options)
        {
            //if(changeTrackerEventHandler != null)
            //{
            //    ChangeTracker.Tracked += changeTrackerEventHandler.TrackedHandler;
            //    ChangeTracker.StateChanged += changeTrackerEventHandler.StateChangeHandler;
            //    SavingChanges += changeTrackerEventHandler.SavingChangesHandler;
            //    SavedChanges += changeTrackerEventHandler.SavedChangesHandler;
            //    SaveChangesFailed += changeTrackerEventHandler.SaveChangesFailHandler;
            //}
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            Module3Seeding.Seed(modelBuilder);
            Module6Seeding.Seed(modelBuilder);
            Module9Seeding.Seed(modelBuilder);
            SomeConfiguration(modelBuilder);
            Scalars.RegisterFunctions(modelBuilder);

            
        }

        [DbFunction]
        public int InvoiceDetailSum(int invoiceId)
        {
            return 0;
        }

        private void SomeConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CinemaWithoutLocation>().ToSqlQuery("Select Id, Nam FROM Cinemas").ToView(null);

            modelBuilder.Entity<MovieWithCount>().ToView("MoviesWithCounts");

            modelBuilder.Ignore<Address>();

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    foreach (var property in entityType.GetProperties())
            //    {
            //        if (property.ClrType == typeof(string)
            //            && property.Name.Contains("URL", StringComparison.CurrentCultureIgnoreCase))
            //        {
            //            property.SetIsUnicode(false);
            //        }
            //    }
            //}

            modelBuilder.Entity<Merchandising>().ToTable("Merchandising");
            modelBuilder.Entity<RentableMovie>().ToTable("RentableMovies");

            var movie1 = new RentableMovie()
            {
                Id = 1,
                Name = "Spider-Man",
                MovieId = 1,
                Price = 5.99m
            };

            var merch1 = new Merchandising()
            {
                Id = 2,
                Available = true,
                IsClothing = true,
                Name = "One Piece T-Shirt",
                Weight = 1,
                Volume = 1,
                Price = 11
            };

            modelBuilder.Entity<Merchandising>().HasData(merch1);
            modelBuilder.Entity<RentableMovie>().HasData(movie1);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    ProcessSaveChanges();
        //    return base.SaveChangesAsync(cancellationToken);
        //}

            //private void ProcessSaveChanges()
            //{
            //    foreach (var item in ChangeTracker.Entries()
            //        .Where(e => e.State == EntityState.Added && e.Entity is AuditableEntity))
            //    {
            //        var entity = item.Entity as AuditableEntity;
            //        entity.CreatedBy = "Felipe";
            //        entity.ModifiedBy = "Felipe";
            //    }

            //    foreach (var item in ChangeTracker.Entries()
            //        .Where(e => e.State == EntityState.Modified && e.Entity is AuditableEntity))
            //    {
            //        var entity = item.Entity as AuditableEntity;
            //        entity.ModifiedBy = "Felipe";
            //        item.Property(nameof(entity.CreatedBy)).IsModified = false;
            //    }
            //}

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaOffer> CinemaOffers { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<CinemaWithoutLocation> CinemasWithoutLocations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CinemaDetail> CinemaDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
