using System;
using System.Collections.Generic;
using System.IO; // Added to handle file operations

class Program
{
    static List<string> exhibitions = new List<string> 
    { 
        "Modern Art - Gallery A", 
        "Sculpture Wonders - Gallery B",
        "Classic Paintings - Gallery C"
    };

    static string bookingFile = "bookings.txt"; // File to store bookings

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🎨 USW Art Exhibition Booking System 🎨");
            Console.WriteLine("1. View Exhibitions");
            Console.WriteLine("2. Book a Slot");
            Console.WriteLine("3. View Bookings");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine()?.Trim(); // Ensuring input is trimmed and null-safe

            switch (choice)
            {
                case "1":
                    ViewExhibitions();
                    break;
                case "2":
                    BookSlot();
                    break;
                case "3":
                    ViewBookings();
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void ViewExhibitions()
    {
        Console.WriteLine("\nAvailable Exhibitions:");
        foreach (var exhibition in exhibitions)
        {
            Console.WriteLine($"- {exhibition}");
        }
        Console.WriteLine("\nPress Enter to return...");
        Console.ReadLine();
    }

    static void BookSlot()
    {
        Console.WriteLine("\nEnter your name: ");
        string name = Console.ReadLine()?.Trim() ?? "Guest"; // Prevents null error

        Console.WriteLine("\nSelect an exhibition to book:");
        for (int i = 0; i < exhibitions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {exhibitions[i]}");
        }

        Console.Write("\nEnter choice: ");
        string? input = Console.ReadLine(); // Read input separately before parsing
        if (int.TryParse(input, out int selection) && selection >= 1 && selection <= exhibitions.Count)
        {
            string bookingDetails = $"{DateTime.Now}: {name} booked {exhibitions[selection - 1]}\n";
            
            // Save booking to a file
            File.AppendAllText(bookingFile, bookingDetails);
            
            Console.WriteLine($"\n{name}, you have successfully booked a slot for {exhibitions[selection - 1]}.");
        }
        else
        {
            Console.WriteLine("\nInvalid selection.");
        }

        Console.WriteLine("\nPress Enter to return...");
        Console.ReadLine();
    }

    static void ViewBookings()
    {
        Console.WriteLine("\n🔹 Booking History:");
        if (File.Exists(bookingFile))
        {
            string[] bookings = File.ReadAllLines(bookingFile);
            if (bookings.Length == 0)
            {
                Console.WriteLine("No bookings found.");
            }
            else
            {
                foreach (var booking in bookings)
                {
                    Console.WriteLine(booking);
                }
            }
        }
        else
        {
            Console.WriteLine("No bookings found.");
        }
        
        Console.WriteLine("\nPress Enter to return...");
        Console.ReadLine();
    }
}
