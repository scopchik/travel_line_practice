namespace CarFactory.Models.CarColor
{
    public static class ColorFactory
    {
        public static Dictionary<string, Func<ICarColor>> Colors { get; } = new Dictionary<string, Func<ICarColor>>()
    {
        { "1", () => new Black() },
        { "2", () => new Silver() },
        { "3", () => new White() }
    };

        public static ICarColor CreateColor( string key )
        {
            if ( Colors.TryGetValue( key, out var colorFactory ) )
            {
                return colorFactory();
            }

            throw new ArgumentException( "Unknown color." );
        }

        public static void PrintAvailableColors()
        {
            Console.WriteLine( "Select color (type number):" );
            foreach ( var key in Colors.Keys )
            {
                Console.WriteLine( $"{key}) {GetColorName( key )}" );
            }
        }

        private static string GetColorName( string key )
        {
            return key switch
            {
                "1" => "Black",
                "2" => "Silver",
                "3" => "White",
                _ => "Unknown"
            };
        }
    }
}