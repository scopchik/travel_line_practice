namespace CarFactory.Models.BodyShape
{
    public static class BodyShapeFactory
    {
        public static Dictionary<string, Func<IBodyShape>> BodyShapes { get; } = new Dictionary<string, Func<IBodyShape>>()
    {
        { "1", () => new Hatchback() },
        { "2", () => new Sedan() },
        { "3", () => new Universal() }
    };

        public static IBodyShape CreateBodyShape( string key )
        {
            if ( BodyShapes.TryGetValue( key, out var bodyShapeFactory ) )
            {
                return bodyShapeFactory();
            }

            throw new ArgumentException( "Unknown color." );
        }

        public static void PrintAvailableBodyShapes()
        {
            Console.WriteLine( "Select bodyshape (type number):" );
            foreach ( var key in BodyShapes.Keys )
            {
                Console.WriteLine( $"{key}) {GetBodyShapeName( key )}" );
            }
        }

        private static string GetBodyShapeName( string key )
        {
            return key switch
            {
                "1" => "Hatchback",
                "2" => "Sedan",
                "3" => "Universal",
                _ => "Unknown"
            };
        }
    }
}