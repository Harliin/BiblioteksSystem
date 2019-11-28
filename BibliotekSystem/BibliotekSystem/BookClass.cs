using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BibliotekSystem
{
    class BookClass
    {
        public string title { get; set; }
        public string author { get; set; }

        public BookClass(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        //Metoder för att hantera Books text fil
        internal static void AddBook(BookClass book)
        {
            File.AppendAllText(@"Books.txt",
                book.title + "," + book.author + "\n");
        }

        internal static void RemoveBook()
        {
            if (!File.Exists(@"Books.txt"))
            {
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"Books.txt"));
                foreach (var item in file)
                {
                    Console.WriteLine($"Bok {rowId}: {item}");
                    rowId++;
                }
                Console.Write("Vilken bok vill du ta bort? Ange bokens nummer: ");
                int row = int.Parse(Console.ReadLine());
                file.RemoveAt(row - 1);
                File.WriteAllLines(@"Books.txt", file.ToArray());
            }
            else
            {
                Console.WriteLine("Bok listan är tom!");
            }
        }
        internal static void ShowBooks()
        {
            if (File.Exists(@"Books.txt"))
            {
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"Books.txt"));
                foreach (var item in file)
                {
                    Console.WriteLine($"Bok {rowId}: {item}");
                    rowId++;
                }
            }
            else
            {
                Console.WriteLine("Vanliga bok listan är tom!");
            }

            Console.WriteLine($"\nSnuskböcker");
            Console.WriteLine("____________\n");
            if (File.Exists(@"DirtyBooks.txt"))
            {
                int dirtyRowId = 1;
                var dirtyFile = new List<string>(File.ReadAllLines(@"DirtyBooks.txt"));
                foreach (var item in dirtyFile)
                {
                    Console.WriteLine($"Bok {dirtyRowId}: {item}");
                    dirtyRowId++;
                }
            }
            else
            {
                Console.WriteLine("Det finns inga snuskiga böcker!");
            }



            
        }
    }
}
