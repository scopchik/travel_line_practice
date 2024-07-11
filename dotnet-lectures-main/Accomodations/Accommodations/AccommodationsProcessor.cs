using System.Globalization;
using Accommodations.Commands;
using Accommodations.Dto;

namespace Accommodations;

public static class AccommodationsProcessor
{
    private static BookingService _bookingService = new();
    private static Dictionary<int, ICommand> _executedCommands = new();
    private static int s_commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine("Booking Command Line Interface");
        Console.WriteLine("Commands:");
        Console.WriteLine("'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room");
        Console.WriteLine("'cancel <BookingId>' - to cancel a booking");
        Console.WriteLine("'undo' - to undo the last command");
        Console.WriteLine("'find <BookingId>' - to find a booking by ID");
        Console.WriteLine("'search <StartDate> <EndDate> <CategoryName>' - to search bookings");
        Console.WriteLine("'exit' - to exit the application");

        string input;
        while ((input = Console.ReadLine()) != "exit")
        {
            try
            {
                ProcessCommand(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    private static void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string commandName = parts[0];

        try
        {
            switch (commandName)
            {
                case "book":
                    if (parts.Length != 6)
                    {
                        Console.WriteLine("Invalid number of arguments for booking.");
                        return;
                    }

                    CurrencyDto currency = (CurrencyDto)Enum.Parse(typeof(CurrencyDto), parts[5], true);

                    int userId = int.Parse(parts[1]);
                    DateTime startDate = DateTime.Parse(parts[3]);
                    DateTime endDate = DateTime.Parse(parts[4]);
                    if (startDate <= DateTime.Now)
                    {
                        throw new ArgumentException("Invalid date, because date must be greater then now date.");
                    }
                    BookingDto bookingDto = new()
                    {
                        UserId = userId,
                        Category = parts[2],
                        StartDate = startDate,
                        EndDate = endDate,
                        Currency = currency,
                    };

                    BookCommand bookCommand = new(_bookingService, bookingDto);
                    bookCommand.Execute();
                    _executedCommands.Add(++s_commandIndex, bookCommand);
                    Console.WriteLine("Booking command run is successful.");
                    break;

                case "cancel":
                    if (parts.Length != 2)
                    {
                        Console.WriteLine("Invalid number of arguments for canceling.");
                        return;
                    }

                    Guid bookingId = Guid.Parse(parts[1]);
                    CancelBookingCommand cancelCommand = new(_bookingService, bookingId);
                    cancelCommand.Execute();
                    _executedCommands.Add(++s_commandIndex, cancelCommand);
                    Console.WriteLine("Cancellation command run is successful.");
                    break;

                case "undo":
                    if (_executedCommands.Count == 0)
                    {
                        Console.WriteLine("No commands to undo.");
                        return;
                    }
                    if (commandName == "cancel")
                    {
                        CancelBookingCommand cancelCommandUndo = new(_bookingService, Guid.Parse(parts[1]));
                        cancelCommandUndo.Undo();
                    }
                    if (_executedCommands.ContainsKey(s_commandIndex))
                    {
                        _executedCommands[s_commandIndex].Undo();
                        _executedCommands.Remove(s_commandIndex);
                        s_commandIndex--;
                        Console.WriteLine("Last command undone.");
                    }
                    else
                    {
                        Console.WriteLine("No command to undo at this index.");
                    }
                    break;

                case "find":
                    if (parts.Length != 2)
                    {
                        Console.WriteLine("Invalid arguments for 'find'. Expected format: 'find <BookingId>'");
                        return;
                    }

                    Guid id = Guid.Parse(parts[1]);
                    FindBookingByIdCommand findCommand = new(_bookingService, id);
                    findCommand.Execute();
                    break;

                case "search":
                    if (parts.Length != 4)
                    {
                        Console.WriteLine("Invalid arguments for 'search'. Expected format: 'search <StartDate> <EndDate> <CategoryName>'");
                        return;
                    }

                    DateTime searchStartDate = DateTime.Parse(parts[1]);
                    DateTime searchEndDate = DateTime.Parse(parts[2]);
                    string categoryName = parts[3];
                    SearchBookingsCommand searchCommand = new(_bookingService, searchStartDate, searchEndDate, categoryName);
                    searchCommand.Execute();
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Invalid input format: {ex.Message}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Missing input value: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid argument: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
