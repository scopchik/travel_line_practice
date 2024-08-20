namespace CarFactory.Models.Transmission
{
    public static class TransmissionFactory
    {
        public static Dictionary<string, Func<ITransmission>> Transmissions { get; } = new Dictionary<string, Func<ITransmission>>()
    {
        { "1", () => new AutomaticlTransmission() },
        { "2", () => new ManualTransmission() },
        { "3", () => new PowerfullManualTransmission() }
    };

        public static ITransmission CreateTransmission( string key )
        {
            if ( Transmissions.TryGetValue( key, out var transmissionFactory ) )
            {
                return transmissionFactory();
            }

            throw new ArgumentException( "Unknown transmission type." );
        }

        public static void PrintAvailableTransmissions()
        {
            Console.WriteLine( "Select transmission (type number):" );
            foreach ( var key in Transmissions.Keys )
            {
                Console.WriteLine( $"{key}) {GetTransmissionName( key )}" );
            }
        }

        private static string GetTransmissionName( string key )
        {
            return key switch
            {
                "1" => "Automatic",
                "2" => "Manual",
                "3" => "Powerfull manual",
                _ => "Unknown"
            };
        }
    }
}