using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Play
{
    public int Id { get; private init; }
    public string Name { get; private init; }
    public DateTime StartDate { get; private init; }
    public DateTime EndDate { get; private init; }
    [Column( TypeName = "money" )]
    public decimal Price { get; private init; }
    public string Description { get; private init; }

    public int TheaterId { get; private init; }
    [JsonIgnore]
    public Theater Theater { get; private init; }

    public int CompositionId { get; private init; }
    [JsonIgnore]
    public Composition Composition { get; private init; }

    public Play(
        string name,
        DateTime startDate,
        DateTime endDate,
        decimal price,
        string description,
        int theaterId,
        int compositionId )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentNullException( $"{nameof( name )} cannot be null or white spaces." );
        }
        if ( price < 0 )
        {
            throw new ArgumentException( $"{nameof( price )} cannot be less than 0." );
        }
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
        Description = description;
        TheaterId = theaterId;
        CompositionId = compositionId;
    }
}