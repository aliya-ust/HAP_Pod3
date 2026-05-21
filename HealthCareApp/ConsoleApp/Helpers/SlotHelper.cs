using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthApp.ConsoleApp.Helpers
{
    public static class SlotHelper
    {
        // Fixed clinic slots — single source of truth
        public static readonly List<string> AvailableSlots = new List<string>
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
        public static string PickSlot()
        {
            System.Console.WriteLine("\nAvailable Time Slots:");
            for (int i = 0; i < AvailableSlots.Count; i++)
            {
                System.Console.WriteLine($"  {i + 1}. {AvailableSlots[i]}");
            }

            System.Console.Write("Pick a slot (1-8): ");
            int choice = int.Parse(System.Console.ReadLine());

            // Validate choice is in range
            if (choice < 1 || choice > AvailableSlots.Count)
                throw new ArgumentException("Invalid slot choice.");

            return AvailableSlots[choice - 1]; // return the actual string
        }
    }
}