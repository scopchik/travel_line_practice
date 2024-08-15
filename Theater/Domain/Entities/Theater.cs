using System.Text.Json.Serialization;

namespace Domain.Entities;
public class Theater
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime OpeningDate { get; set; }

    [JsonIgnore]
    public IReadOnlyList<WorkingHours> WorkingHours { get; private init; } = new List<WorkingHours>();
    [JsonIgnore]
    public IReadOnlyList<Play> Plays { get; private init; } = new List<Play>();
    public Theater( string name, string address, string phoneNumber, string description, DateTime openingDate )
    {
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Description = description;
        OpeningDate = openingDate;
    }

    public void Update( string? name, string? phoneNumber, string? description )
    {
        if ( !string.IsNullOrWhiteSpace( name ) )
        {
            Name = name;
        }
        if ( !string.IsNullOrWhiteSpace( phoneNumber ) )
        {
            PhoneNumber = phoneNumber;
        }
        if ( !string.IsNullOrEmpty( description ) )
        {
            Description = description;
        }
    }
}
