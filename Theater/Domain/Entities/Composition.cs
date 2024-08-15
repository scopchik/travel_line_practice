using System.Net;
using System.Text;

namespace Domain.Entities;
public class Composition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CharactersInfo { get; set; }
    public IReadOnlyList<Play> Plays { get; set; } = new List<Play>();
    public int AuthorId { get; set; }

    public Composition( string name, string description, int authorId, string charactersInfo )
    {
        Name = name;
        Description = description;
        AuthorId = authorId;
        CharactersInfo = charactersInfo;
    }
    public Composition( int id, string name, string description, int authorId, string charactersInfo )
    {
        Id = id;
        Name = name;
        Description = description;
        AuthorId = authorId;
        CharactersInfo = charactersInfo;
    }



    public override string ToString()
    {
        StringBuilder sb = new( 300 );
        sb.AppendLine( "[Composition]" );
        sb.AppendLine( $"  Id: {Id}" );
        sb.AppendLine( $"  Name: {Name}" );
        sb.AppendLine( $"  Description:{Description}" );

        return sb.ToString();
    }
    public void CopyFrom( Composition other )
    {
        SetName( other.Name );
        SetDescription( other.Description );
    }

    public void SetName( string name )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentException( $"'{nameof( name )}' cannot be null or whitespace.", nameof( name ) );
        }

        Name = name;
    }
    public void SetDescription( string description )
    {
        if ( string.IsNullOrWhiteSpace( description ) )
        {
            throw new ArgumentException( $"'{nameof( description )}' cannot be null or whitespace.", nameof( description ) );
        }

        Description = description;
    }
}
