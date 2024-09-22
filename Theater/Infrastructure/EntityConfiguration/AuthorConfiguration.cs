using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.EntityConfiguration;
public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure( EntityTypeBuilder<Author> builder )
    {
        builder.ToTable( nameof( Author ) )
               .HasKey( a => a.Id );
        builder.Property( a => a.Name )
               .HasMaxLength( 20 )
               .IsRequired();
        builder.Property( a => a.DateOfBirth )
               .IsRequired();
        builder.HasMany( a => a.Compositions )
               .WithOne(/* a => a.AuthorId */)
               .HasForeignKey( a => a.AuthorId );
    }
}
