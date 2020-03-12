using System;
using System.Collections.Generic;
using TVDBSharp.Models;

namespace Examples
{
    public class DisplayUpdates
    {
        public static void Print(List<UpdateTimestamp> updates)
        {
            Console.WriteLine($"{updates.Count} updated shows (ids) ----");
            foreach (var timestamp in updates)
            {
                Console.WriteLine($"show #{timestamp.ShowId}; {timestamp.LastUpdatedAt}");
            }
        }
    }
}