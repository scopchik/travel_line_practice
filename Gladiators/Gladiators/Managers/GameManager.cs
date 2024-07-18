using Fighters.Controller;
using Fighters.Models.Fighters;
using Fighters.Extensions;

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
                case "add":
                    _fighterController.CreateFighter();
                    break;
                case "show":
                    PrintFighterList();
                    break;
                case "clear":
                    _fighterController.Clear();
                    break;
                case "help":
                    PrintMenu();
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

    private void PrintMenu()
    {
        Console.WriteLine( "Command list" );
        Console.WriteLine( "Fight" );
        Console.WriteLine( "Add" );
        Console.WriteLine( "Show" );
        Console.WriteLine( "Clear" );
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
            Console.WriteLine( $"{i} - {fighters[ i ].Info()}" );
        }
    }
}
