using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using TVDBSharp;
using TVDBSharp.Models;

namespace Examples {
    public class DisplaySearchResult {

        public static void Print(List<Show> searchResults)
        {
            foreach (var show in searchResults)
            {
                Console.WriteLine("{0}:\t{1}", show.Name, show.ID);
            }
            Console.ReadKey();
        }
    }
}