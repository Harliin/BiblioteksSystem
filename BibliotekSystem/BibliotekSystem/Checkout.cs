using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BibliotekSystem
{
    class Checkout
    {
        internal static void CheckoutUser()
        {
            
            if (File.Exists(@"Users.txt"))
            {
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"Users.txt"));
                foreach (var item in file)
                {
                    Console.WriteLine($"Lånetagare {rowId}: {item}");
                    rowId++;
                }
            }
        }
    }
}
