﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EFCoreMovies.Entities.Configurations
{
    public class ActorConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(P => P.Name).IsRequired();
            builder.Property(p => p.Biography).HasColumnType("nvarchar(max)");

            //builder.Ignore(p => p.Age);
        }
    }
}
