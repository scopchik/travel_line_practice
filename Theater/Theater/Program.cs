using Infrastructure;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPlayRepository, PlayRepository>();
string connectionString = builder.Configuration.GetConnectionString( "TheaterManagement" );

builder.Services.AddDbContext<TheaterDbContext>( o =>
{
    o.UseSqlServer( connectionString,
        ob => ob.MigrationsAssembly( typeof( TheaterDbContext ).Assembly.FullName ) );
} );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
