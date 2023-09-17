using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //modelBuilder.Entity<Genre>().HasKey(p => p.Identifier);
            builder.Property(P => P.Name).IsRequired();

            builder.HasQueryFilter(g => !g.IsDeleted);
        }
    }
}
