using Fighters.Controller;
using Fighters.Extensions;
using Fighters.Models.Fighters;

namespace Fighters.Managers;

public class GameManager : IGameManager
{
    private IFighterController _fighterController = new FighterController();

    public void Play()
    {
        bool isExit = false;

        PrintMenu();

        while ( !isExit )
        {
            string? str = Console.ReadLine().ToLower();
            switch ( str )
            {
                case "fight":
                    _fighterController.Fight();
                    break;
                case "add fighter":
                    _fighterController.CreateFighter();
                    PrintMenu();
                    break;
                case "show fighters":
                    PrintFighterList();
                    break;
                case "clear fighters":
                    _fighterController.Clear();
                    break;
                case "help":
                    PrintHelp();
                    break;
                case "exit":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine( "Unknown command" );
                    break;
            }
        }
    }

    private void PrintHelp()
    {
        Console.WriteLine( "To add a fighter use add fighter" );
        Console.WriteLine( "To start a fight use fight" );
        Console.WriteLine( "To show fighters use show fighters" );
        Console.WriteLine( "To clear fighters use clear fighters" );
    }

    private void PrintMenu()
    {
        Console.WriteLine( "Command list" );
        Console.WriteLine( "Fight" );
        Console.WriteLine( "Add fighter" );
        Console.WriteLine( "Show fighters" );
        Console.WriteLine( "Clear fighters" );
        Console.WriteLine( "Help" );
        Console.WriteLine( "Exit" );
    }

    private void PrintFighterList()
    {
        List<IFighter> fighters = _fighterController.GetFighters();

        if ( fighters.Count == 0 )
        {
            Console.WriteLine( "List of fighters is empty" );
            return;
        }

        for ( int i = 0; i < fighters.Count; i++ )
        {
            Console.WriteLine( $"{i} - {fighters[ i ].ToString()}" );
        }
    }
}
