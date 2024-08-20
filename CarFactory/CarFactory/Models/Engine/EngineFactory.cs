namespace CarFactory.Models.Engine
{
    public static class EngineFactory
    {
        public static Dictionary<string, Func<IEngine>> Engines { get; } = new Dictionary<string, Func<IEngine>>()
    {
        { "1", () => new RotaryEngine() },
        { "2", () => new EnlineEngine() },
        { "3", () => new VTypeEngine() }
    };

        public static IEngine CreateEngine( string key )
        {
            if ( Engines.TryGetValue( key, out var engineFactory ) )
            {
                return engineFactory();
            }

            throw new ArgumentException( "Unknown engine type." );
        }

        public static void PrintAvailableEngines()
        {
            Console.WriteLine( "Select engine (type number):" );
            foreach ( var key in Engines.Keys )
            {
                Console.WriteLine( $"{key}) {GetEngineName( key )}" );
            }
        }

        private static string GetEngineName( string key )
        {
            return key switch
            {
                "1" => "Rotary",
                "2" => "Enline",
                "3" => "V type",
                _ => "Unknown"
            };
        }
    }
}