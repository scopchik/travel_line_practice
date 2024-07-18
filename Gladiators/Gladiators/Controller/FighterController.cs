using Fighters.Controller;
using Fighters.Extensions;
using Fighters.Models.Fighters;
using Fighters.Models.Race;

namespace Fighters.Controller;

public class FighterController : IFighterController
{
    private List<IFighter> _fighters = new List<IFighter>();

    public List<IFighter> GetFighters() => _fighters;

    public IFighter CreateFighter()
    {
        string name = GetFighterName();
        IRace race = GetRace();
        IFighter fighter = GetFighterWithType( race, name );

        IArmor? armor = GetArmor();
        if ( armor != null )
        {
            fighter.SetArmor( armor );
        }

        IWeapon? weapon = GetWeapon();
        if ( weapon != null )
        {
            fighter.SetWeapon( weapon );
        }
        _fighters.Add( fighter );

        return fighter;
    }

    public void Clear()
    {
        _fighters.Clear();
    }

    public void Fight()
    {
        List<IFighter> leaveFighters = _fighters.Where( fighter => fighter.IsAlive() ).ToList();
        if ( leaveFighters.Count < 2 )
        {
            Console.WriteLine( "Number of living fighters < 2" );
            return;
        }
        Console.WriteLine( "Take number of first fighter who starts battle" );
        IFighter fighter1 = GetFighter();
        Console.WriteLine( "Choose second fighter" );
        IFighter fighter2 = GetFighter();
        while ( fighter1 == fighter2 )
        {
            Console.WriteLine( "First fighter can't fight with himself" );
            fighter2 = GetFighter();
        }
        bool hasWinner = false;
        while ( !hasWinner )
        {
            int firstFighterDamage = fighter1.CalculateDamage();
            int receivedBySecondFighterDamage = fighter2.TakeDamage( firstFighterDamage );
            if ( !fighter2.IsAlive() )
            {
                Console.WriteLine( $"The second fighter {fighter2.Name}. DEAD" );
                hasWinner = true;
                continue;
            }
            Console.WriteLine( $"The first fighter dealt damage - {firstFighterDamage}. The second fighter received damage - {receivedBySecondFighterDamage}." );
            int secondFighterDamage = fighter2.CalculateDamage();
            int receivedByFirstFighterDamage = fighter1.TakeDamage( secondFighterDamage );
            if ( !fighter1.IsAlive() )
            {
                Console.WriteLine( $"The first fighter {fighter1.Name}. DEAD " );
                hasWinner = true;
                continue;
            }
            Console.WriteLine( $"The second fighter dealt damage - {secondFighterDamage}. The first fighter received damage - {receivedByFirstFighterDamage}." );
        }
    }

    private IFighter GetFighterWithType( IRace race, string name )
    {
        const string listOfFighterTypesMsg = """
        Fighters class
        1 - knight
        2 - barbarian
        3 - rogue
        """;

        while ( true )
        {
            Console.WriteLine( listOfFighterTypesMsg );

            string? str = Console.ReadLine();

            switch ( str )
            {
                case "1":
                    return new Knight( race, name );
                case "2":
                    return new Barbarian( race, name );
                case "3":
                    return new Rogue( race, name );
                default:
                    Console.WriteLine( "invalid command" );
                    break;
            }
        }
    }

    private string GetFighterName()
    {
        Console.Write( "Choose your fighters name: " );

        while ( true )
        {
            string? str = Console.ReadLine();

            if ( str == null && string.IsNullOrWhiteSpace( str ) )
            {
                Console.WriteLine( "Invalid name" );
                continue;
            }

            return str.Trim();
        }
    }

    private IRace GetRace()
    {
        const string listOfRacesMsg = """
        Races list
        1 - human
        2 - khajiit
        3 - nord
        """;

        Console.WriteLine( "Choose your fighters race" );

        while ( true )
        {
            Console.WriteLine( listOfRacesMsg );
            string? str = Console.ReadLine();
            switch ( str )
            {
                case "1":
                    return new Human();
                case "2":
                    return new Khajiit();
                case "3":
                    return new Nord();
                default:
                    Console.WriteLine( "Invalid command" );
                    break;
            }
        }
    }

    private IArmor? GetArmor()
    {
        const string listOfRacesMsg = """
        Armor list
        1 - wood armor
        2 - steel armor
        3 - without armor
        """;

        Console.WriteLine( "Choose your fighters armor" );

        while ( true )
        {
            Console.WriteLine( listOfRacesMsg );
            string? str = Console.ReadLine();
            switch ( str )
            {
                case "1":
                    return new WoodArmor();
                case "2":
                    return new SteelArmor();
                case "3":
                    return new NoArmor();
                default:
                    Console.WriteLine( "Invalid command" );
                    break;
            }
        }
    }

    private IWeapon? GetWeapon()
    {
        const string listOfRacesMsg = """
        Weapon list
        1 - mace
        2 - spear
        3 - firsts
        """;

        Console.WriteLine( "Choose your fighters weapon" );

        while ( true )
        {
            Console.WriteLine( listOfRacesMsg );
            string? str = Console.ReadLine();
            switch ( str )
            {
                case "1":
                    return new Mace();
                case "2":
                    return new Spear();
                case "3":
                    return new Fists();
                default:
                    Console.WriteLine( "Invalid command" );
                    break;
            }
        }
    }

    private IFighter GetFighter()
    {
        Console.Write( "Choose number of your fighter: " );

        while ( true )
        {
            string? str = Console.ReadLine();
            int index = 0;
            if ( !int.TryParse( str, out index ) )
            {
                Console.WriteLine( "Incorrect input, try again" );
                continue;
            }
            if ( index >= 0 && index < _fighters.Count )
            {
                return _fighters[ index ];
            }
            Console.WriteLine( "Incorrect number" );
            continue;
        }
    }
}