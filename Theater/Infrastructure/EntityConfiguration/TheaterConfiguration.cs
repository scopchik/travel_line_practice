using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.EntityConfiguration;
public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
{
    public void Configure( EntityTypeBuilder<Theater> builder )
    {
        builder.ToTable( nameof( Theater ) )
               .HasKey( a => a.Id );
        builder.Property( a => a.Name )
               .HasMaxLength( 50 )
               .IsRequired();
        builder.Property( a => a.Address )
               .HasMaxLength( 50 )
               .IsRequired();
        builder.Property( a => a.Description )
               .HasMaxLength( 100 )
               .IsRequired();
        builder.Property( a => a.OpeningDate )
               .IsRequired();
        builder.Property( a => a.PhoneNumber )
               .HasMaxLength( 15 )
               .IsRequired();
        builder.HasMany( t => t.Plays )
               .WithOne(p => p.Theater)
               .HasForeignKey( p => p.TheaterId );
        builder.HasMany( t => t.WorkingHours )
               .WithOne()
               .HasForeignKey( wh => wh.TheaterId );

    }
}