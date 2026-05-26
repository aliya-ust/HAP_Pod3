using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthApp.ConsoleApp.Helpers
{
    public static class SlotHelper
    {
        // Fixed clinic slots — single source of truth
        private static readonly List<string> AvailableSlots = new List<string>
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

        public static void PrintSlots()
        {
            for (int i = 0; i < AvailableSlots.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailableSlots[i]}");
            }
        }

        public static List<string>? SimpleParseSlots(string input)
        {
            var result = new List<string>();

            var parts = input.Split(',');

            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int index) &&
                    index >= 1 && index <= AvailableSlots.Count)
                {
                    var slot = AvailableSlots[index - 1];

                    if (!result.Contains(slot))
                    {
                        result.Add(slot);
                    }
                }
            }

            return result.Count > 0 ? result : null;
        }
    }
}