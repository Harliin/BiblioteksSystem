using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace BibliotekSystem
{
    class UserClass
    {

        public string PN { get; private set; }
        public string password { get; private set; }

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
            if (File.Exists(@"Users.txt"))
            {
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"Users.txt"));
                foreach (var item in file)
                {
                    Console.WriteLine($"Lånetagare {rowId}: {item}");
                    rowId++;
                }
                Console.Write("Vem vill du ta bort? Ange låntagarens nummer: ");
                if (!int.TryParse(Console.ReadLine(), out int row))
                {
                    Console.WriteLine("Ange med siffror!");
                    System.Threading.Thread.Sleep(800);
                }
                else
                {
                    try
                    {
                        file.RemoveAt(row - 1);
                        File.WriteAllLines(@"Users.txt", file.ToArray());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Finns ingen låntagare vid den positionen!");
                        System.Threading.Thread.Sleep(800);
                    }

                }
            }
            else
            {
                Console.WriteLine("Lånetagar listan är tom!");
                Thread.Sleep(900);
            }
        }

        internal static void ShowUsers()
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
            else
            {
                Console.WriteLine("Lånetagar listan är tom!");
                Thread.Sleep(900);
            }
        }
        //Slut hantera users text fil
        internal static void AddBookToUser()
        {
            if (File.Exists(@"Books.txt"))
            {
                bool didWork = false;
                string tempBook = "";
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"Books.txt"));
                foreach (var item in file)
                {
                    Console.WriteLine($"Bok {rowId}: {item}");
                    rowId++;
                }
                Console.Write("Vilken bok vill du låna? Ange bokens nummer: ");
                try
                {
                    int row = int.Parse(Console.ReadLine());
                    tempBook = file[row - 1];
                    didWork = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Finns ingen bok med det nummret!");
                    System.Threading.Thread.Sleep(800);
                }
                if (didWork)
                {
                    if (!File.Exists(@"ShoppingBasket.txt"))
                    {
                        File.WriteAllText(@"ShoppingBasket.txt", string.Empty);
                    }
                    var loanList = new List<string>();
                    loanList.Add(tempBook + "," + File.ReadAllText(@"ShoppingBasket.txt"));

                    File.WriteAllLines(@"ShoppingBasket.txt", loanList.ToArray());
                }
                
            }
            else
            {
                Console.WriteLine("Finns inga böcker att låna!");
                Console.ReadKey();
            }
        }

        internal static void AddDirtyBookToUser()
        {
            if (File.Exists(@"DirtyBooks.txt"))
            {
                Console.Clear();
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"DirtyBooks.txt"));
                Console.WriteLine("Låna snuskbok");
                Console.WriteLine("________\n");
                Console.WriteLine("Här är listan på tillgängliga böcker");
                Console.WriteLine("____________________________________");
                foreach (var item in file)
                {
                    Console.WriteLine($"Snuskbok {rowId}: {item}");
                    rowId++;
                }
                
                Console.Write("Vilken bok vill du låna? Ange bokens nummer: ");
                int row = int.Parse(Console.ReadLine());
                string tempBook ="default";
                try { tempBook = file[row - 1]; }

                catch  (Exception e) 
                {
                    AddDirtyBookToUser();
                }
                
                if (!File.Exists(@"ShoppingBasket.txt"))
                {
                    File.WriteAllText(@"ShoppingBasket.txt", "");
                }
                var loanList = new List<string>(File.ReadLines(@"ShoppingBasket.txt"));
                loanList.Add(tempBook);

                File.WriteAllLines(@"ShoppingBasket.txt", loanList.ToArray());
                Console.WriteLine("Boken är nu tillagd i kundkorgen, checka ut för att slutföra lånet.");
                Thread.Sleep(1400);
            }
            else
            {
                Console.WriteLine("Finns inga böcker att låna!");
                Console.ReadKey();
            }

        }

        internal static void ShowUserBooks()
        {
            if (File.Exists(@"ShoppingBasket.txt"))
            {
                int rowId = 1;
                var file = new List<string>(File.ReadAllLines(@"ShoppingBasket.txt"));

                foreach (var item in file)
                {
                    string[] array = item.Split(",");
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        Console.WriteLine($"Bok {rowId}: {array[i]}, Författare: {array[i + 1]}");
                        i++;
                        rowId++;
                    }


                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nDin kundkorg är tom!");
                Console.ReadKey();
            }
        }
    

        internal static void ReturnBooks()
        {
            if (File.Exists(@"CurrentLoans.txt"))
            {
                var file = new List<string>(File.ReadAllLines(@"CurrentLoans.txt"));

                Console.Write("Skriv in ditt personnummer:");
                string tempPN = Console.ReadLine();

                Console.Write("Skriv in lösenordet: ");
                string tempPW = Console.ReadLine();
                for (int i = 0; i < file.Count; i++)
                {
                    if (file[i] == "")
                    {
                        continue;
                    }
                    else if (file[i].Substring(0, 11) == tempPN)
                    {
                        if (file[i].Substring(12, 4) == tempPW)
                        {
                            bool loop = true;
                            do
                            {
                                Console.WriteLine("Vill du returnera dina böcker?\n[1] Ja\n[2] Nej");
                                char answer = Console.ReadKey(true).KeyChar;
                                switch (answer)
                                {
                                    case '1':
                                        {
                                            file[i] = string.Empty;
                                            Console.WriteLine("Dina böcker är returnerade!");
                                            File.WriteAllLines(@"CurrentLoans.txt", file.ToArray());
                                            System.Threading.Thread.Sleep(800);
                                            loop = false;
                                            break;
                                        }
                                    case '2':
                                        {
                                            loop = false;
                                            break;
                                        }
                                    default:
                                        break;
                                }
                            } while (loop);
                        }
                        else
                        {
                            Console.WriteLine("Fel Användarnamn eller lösenord!");
                            System.Threading.Thread.Sleep(800);
                        }
                    }
                }
                
            }
            else
            {
                Console.WriteLine("finns inga registrerade lånetagare");
                System.Threading.Thread.Sleep(800);
            }
        }

    }
}

