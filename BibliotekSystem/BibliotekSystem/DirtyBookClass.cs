using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace BibliotekSystem
{
    class DirtyBookClass
    {
        public string title { get; set; }
        public string author { get; set; }

        public DirtyBookClass(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        internal static bool DirtyLogin()
        {
            Console.WriteLine("Ange ditt personnummer, 11 siffror: ");
            
            string input = Console.ReadLine();
           // string lastFourDigits = input.Substring(0, 6); 901216-2814
            if (Constrains.CheckUser(input).Item1 == true)
            {
                Console.WriteLine("Ange ditt lösenord: ");
                int.TryParse(Console.ReadLine(), out int passwordResult);
                string passwordInput = passwordResult.ToString();
                if (File.Exists(@"Users.txt"))
                {
                    int rowId = 1;
                    var file = new List<string>(File.ReadAllLines(@"Users.txt"));
                    foreach (var person in file)
                    {
                        if (person.Substring(0, 11) == input)
                        {
                            if (person.Substring(12) == passwordInput)
                            {
                                Console.WriteLine("Du har åldern inne! ");
                                Thread.Sleep(900);
                                return (true);
                            }
                            else
                            {
                                Console.WriteLine("Fel användarnamn eller lösenord!");
                                Thread.Sleep(900);
                                return false;
                            }
                        }
                        else return (false);
                        // kolla så att lösenord och pnr ligger på samma rad
                    }
                    
                }
                else Console.WriteLine("Bok listan är tom!");
                Thread.Sleep(900);
                return false;
            }
            else
            {
                Console.WriteLine("Du är för ung för att hyra sådana böcker");
                Thread.Sleep(900);
                return (false);
            }
            
        }

        //Metoder för att hantera Books text fil
        internal static void AddDirtyBook(DirtyBookClass book)
        {
            File.AppendAllText(@"DirtyBooks.txt",
                book.title + ", " + book.author + "\n");
        }

        internal static void RemoveDirtyBook()
        {
            if (File.Exists(@"DirtyBooks.txt"))
            {
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"DirtyBooks.txt"));
                foreach (var item in file)
                {
                    Console.WriteLine($"Bok {rowId}: {item}");
                    rowId++;
                }
                Console.Write("Vilken bok vill du ta bort? Ange bokens nummer: ");
                int row = int.Parse(Console.ReadLine());
                file.RemoveAt(row - 1);
                File.WriteAllLines(@"DirtyBooks.txt", file.ToArray());
            }
            else
            {
                Console.WriteLine("Bok listan är tom!");
            }

        }
        internal static void ShowDirtyBooks()
        {
            if (File.Exists(@"DirtyBooks.txt"))
            {
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"DirtyBooks.txt"));
                foreach (var item in file)
                {
                    Console.WriteLine($"Bok {rowId}: {item}");
                    rowId++;
                }
            }
            else
            {
                Console.WriteLine("Bok listan är tom!");
            }
        }
    }
}
