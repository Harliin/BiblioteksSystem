using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BibliotekSystem
{
    class UserClass
    {
        
        public string PN { get; set; }
        public string password { get; set; }

        public int ID { get; set; }
        private static int _idCounter = 1;

        public UserClass(string pn, string password)
        {
            this.PN = pn;
            this.password = password;

            this.ID = _idCounter;
            _idCounter++;
        }

        //Metoder för att hantera Users text fil
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
        //Slut hantera users text fil
    }
}
