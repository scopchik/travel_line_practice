using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration;
public class CompositionConfiguration : IEntityTypeConfiguration<Composition>
{
    public void Configure( EntityTypeBuilder<Composition> builder )
    {
        builder.ToTable( nameof( Composition ) )
               .HasKey( a => a.Id );
        builder.Property( a => a.Name )
               .HasMaxLength( 20 )
               .IsRequired();
        builder.Property(a => a.Description )
               .HasMaxLength( 50 )
               .IsRequired();
        builder.HasMany( c => c.Plays )
            .WithOne( p => p.Composition )
            .HasForeignKey( p => p.CompositionId );
    }
}
