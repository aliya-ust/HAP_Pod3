using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthApp.ConsoleApp.Helpers
{
    public class SlotHelper
    {
        // Fixed clinic slots
        public readonly List<string> AvailableSlots = new List<string>
        {
            "09:00 AM",
            "10:00 AM",
            "11:00 AM",
            "12:00 PM",
            "02:00 PM",
            "03:00 PM",
            "04:00 PM",
            "05:00 PM"
        };

        // Displays slots and returns the one the user picks
        public string PickSlot()
        {
            Console.WriteLine("\nAvailable Time Slots:");
            for (int i = 0; i < AvailableSlots.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {AvailableSlots[i]}");
            }
            Console.Write("\nChoose slot (1-8): ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int slotChoice)
                || slotChoice < 1 || slotChoice > 8)
            {
                PrintError("Please enter a number between 1 and 8.");
                Pause();
                return "";
            }
            {
                PrintError("Please enter a number between 1 and 8.");
                Pause(); 
                return "";
            }

            return AvailableSlots[slotChoice - 1]; 
        }
        private static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{msg}");
            Console.ResetColor();
        }
        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
        }
    }
}