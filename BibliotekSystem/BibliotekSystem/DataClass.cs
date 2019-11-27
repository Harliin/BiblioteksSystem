using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BibliotekSystem
{
    internal static class DataClass
    {
        internal static void AddUser(UserClass user)
        {
            File.AppendAllText(@"Users.txt",
                user.PN + "," + user.password + "\n");
        }
        internal static void RemoveUser()
        {
            int rowId = 1;
            var file = new List<string>(File.ReadAllLines(@"Users.txt"));
            foreach (var item in file)
            {
                Console.WriteLine($"Lånetagare {rowId}: {item}");
                rowId++;
            }
            Console.Write("Vem vill du ta bort? Ange låntagarens nummer: ");
            int row = int.Parse(Console.ReadLine());
            file.RemoveAt(row - 1);
            File.WriteAllLines(@"Users.txt", file.ToArray());
        }

        internal static void ShowUsers()
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
