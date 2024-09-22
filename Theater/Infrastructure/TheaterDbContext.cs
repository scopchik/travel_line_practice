using Domain.Entities;
using Infrastructure.Configuration;
using Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Infrastructure;

public class TheaterDbContext : DbContext
{
    public TheaterDbContext( DbContextOptions<TheaterDbContext> options )
        : base( options )
    {
    }
    //public TheaterDbContext()
    //    : base()
    //{
    //}

    //protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    //{
    //    base.OnConfiguring( optionsBuilder );
    //    optionsBuilder.UseSqlServer( "Server=localhost\\SQLEXPRESS;Database=Theater;Trusted_Connection=true;TrustServerCertificate=True;" );
    //}
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );
        modelBuilder.ApplyConfiguration( new PlayConfiguration() );
        modelBuilder.ApplyConfiguration( new TheaterConfiguration() );
        modelBuilder.ApplyConfiguration( new AuthorConfiguration() );
        modelBuilder.ApplyConfiguration( new CompositionConfiguration() );
        modelBuilder.ApplyConfiguration( new WorkingHoursConfiguration() );
    }
}