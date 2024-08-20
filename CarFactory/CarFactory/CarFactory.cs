using CarFactory.Models.BodyShape;
using CarFactory.Models.Car;
using CarFactory.Models.CarColor;
using CarFactory.Models.Engine;
using CarFactory.Models.SteeringPositions;
using CarFactory.Models.Transmission;

namespace CarFactory
{
    public class CarFactory
    {
        List<ICar> _cars = new();

        public void Run()
        {
            string userCommand = "";
            while ( userCommand != "4" )
            {
                Console.Clear();
                PrintMenu();
                userCommand = Console.ReadLine();
                if ( userCommand == "4" )
                {
                    break;
                }
                try
                {
                    ProcessCommand( userCommand );
                }
                catch ( ArgumentException e )
                {
                    Console.WriteLine( $"Error: {e.Message}" );
                }
                Console.WriteLine( "Tap enter to continue" );
                userCommand = Console.ReadLine();
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine( "Menu:" );
            Console.WriteLine( "1 - Create new car" );
            Console.WriteLine( "2 - Print all car" );
            Console.WriteLine( "3 - Remove car" );
        }

        private void ProcessCommand( string userCommand )
        {
            switch ( userCommand )
            {
                case "1":
                    CreateNewCar();
                    break;
                case "2":
                    PrintAllCars();
                    break;
                case "3":
                    RemoveCar();
                    break;
                default:
                    Console.WriteLine( "Unknown command" );
                    break;
            }
        }

        private void CreateNewCar()
        {
            Car car = new Car(
                name: GetNameFromInput(),
                engine: GetEngineFromInput(),
                transmission: GetTransmissionFromInput(),
                bodyShape: GetBodyShapeFromInput(),
                color: GetCarColorFromInput(),
                steeringPosition: GetSteeringPositionFromInput()
            );

            _cars.Add( car );
            Console.WriteLine();
            Console.WriteLine( car );
            Console.WriteLine();
            Console.WriteLine( "New car was created" );
        }

        private string GetNameFromInput()
        {
            Console.Write( "Enter name: " );
            string name = Console.ReadLine();
            while ( String.IsNullOrWhiteSpace( name ) )
            {
                Console.WriteLine( "Name can not be empty or contain only spaces" );
                Console.Write( "Please enter again: " );
                name = Console.ReadLine();
            }

            return name;
        }
        private static IEngine GetEngineFromInput()
        {
            EngineFactory.PrintAvailableEngines();

            while ( true )
            {
                try
                {
                    string input = Console.ReadLine();
                    return EngineFactory.CreateEngine( input );
                }
                catch ( ArgumentException ex )
                {
                    Console.WriteLine( ex.Message + " Please try again." );
                }
            }
        }

        private static ITransmission GetTransmissionFromInput()
        {
            TransmissionFactory.PrintAvailableTransmissions();

            while ( true )
            {
                try
                {
                    string input = Console.ReadLine();
                    return TransmissionFactory.CreateTransmission( input );
                }
                catch ( ArgumentException ex )
                {
                    Console.WriteLine( ex.Message + " Please try again." );
                }
            }
        }
        private static IBodyShape GetBodyShapeFromInput()
        {
            BodyShapeFactory.PrintAvailableBodyShapes();

            while ( true )
            {
                try
                {
                    string input = Console.ReadLine();
                    return BodyShapeFactory.CreateBodyShape( input );
                }
                catch ( ArgumentException ex )
                {
                    Console.WriteLine( ex.Message + " Please try again." );
                }
            }
        }
        private static ICarColor GetCarColorFromInput()
        {
            ColorFactory.PrintAvailableColors();

            while ( true )
            {
                try
                {
                    string input = Console.ReadLine();
                    return ColorFactory.CreateColor( input );
                }
                catch ( ArgumentException ex )
                {
                    Console.WriteLine( ex.Message + " Please try again." );
                }
            }
        }

        private SteeringPosition GetSteeringPositionFromInput()
        {
            Console.WriteLine( "Enter steering position (left/right)" );
            SteeringPosition position;
            while ( !Enum.TryParse( Console.ReadLine(), true, out position ) )
            {
                Console.WriteLine( "Unknown steering position. Please try again" );
            }
            return position;
        }

        private void PrintAllCars()
        {
            _cars.ForEach( car => Console.WriteLine( car ) );

            Console.WriteLine( "All cars was printed" );
        }

        private void RemoveCar()
        {
            PrintAllCars();
            Console.WriteLine( "Enter number of car (start from 0)" );
            if ( int.TryParse( Console.ReadLine(), out int index ) )
            {
                if ( index >= 0 && index < _cars.Count )
                {
                    var carToRemove = _cars[ index ];
                    _cars.RemoveAt( index );
                    Console.WriteLine( $"Car '{carToRemove.Name}' was removed." );
                }
                else
                {
                    Console.WriteLine( "Invalid index. No car removed." );
                }
            }
            else
            {
                Console.WriteLine( "Invalid input. Please enter a number." );
            }
        }
    }
}
