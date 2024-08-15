using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public IReadOnlyList<Composition> Compositions { get; set; } = new List<Composition>();

    public Author(string name, DateTime dateOfBirth)
    {
        Name = name;
        DateOfBirth = dateOfBirth;
    }
    public void Update( string? name, DateTime dateOfBirth )
    {
        if ( !string.IsNullOrWhiteSpace( name ) )
        {
            Name = name;
        }
        DateOfBirth = dateOfBirth;
    }
}
