using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class CinemaConfig : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            builder.HasOne(c => c.CinemaDetail).WithOne(c => c.Cinema).HasForeignKey<CinemaDetail>(cd => cd.Id);
        }

        
    }
}
