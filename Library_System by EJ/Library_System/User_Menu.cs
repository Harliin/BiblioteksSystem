using System;

namespace Library_System
{
    class User_Menu
    {
        // Anropas från Main_Menu 
        public void Login()
        {
            Console.Clear();
            Console.WriteLine("\nSkriv ditt användernamn: ");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Ange lösenord: ");
            string inputPassword = Console.ReadLine();

            if (IsLoggedIn(inputUsername, inputPassword) == true)
            {
                UserMenu();
            }
            else
            {
                Console.WriteLine("Felaktigt användernamn eller lösenord. Försök igen.");
                Console.ReadKey();
                Login();
            }
        }
        public bool IsLoggedIn(string inputName, string inputPass)
        {
            bool isRegistered = true;

            foreach (var item in Admin.users)
            {
                if (inputName.Contains(item.GetUsername()) && inputPass.Contains(item.GetPassword()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return isRegistered;
        }



        // Users menu open
        public static void UserMenu()
        {
            Console.Clear();
            Console.WriteLine($"Välkommen \nGör ditt val:");
            Console.WriteLine("1. Låna bok\n2. Återlämna\n3. Visa utlånade böcker\n0. Logga ut");

            ConsoleKeyInfo key = Console.ReadKey();
            string select = key.KeyChar.ToString();

            if (select == "1" || select == "2" || select == "3" || select == "0")
            {
                switch (select)
                {
                    case "1":
                        LoanBook();
                        break;
                    case "2":
                        // ReturnBook();
                        break;
                    case "3":
                        // LoanedBooks()
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Vill du logga ut?  y/n");
                        string logout = Console.ReadLine();
                        if (logout == "y")
                        {
                            Main_Menu.MainMenu();
                        }
                        else
                        {
                            UserMenu();
                        }
                        break;
                }
            }
            else
            {
                Console.Clear();
                UserMenu();
            }
        }

        // anropas från User.UserMenu() 
        public static void LoanBook()
        {
            Console.Clear();
            foreach (var item in Admin.books)
            {
                Console.WriteLine(item.GetID() + "." + item.GetTitle() + " by " + item.GetAuthor());
            }
            Console.WriteLine("\n\nVälj bok från hyllan genom att ange bokens ID-nummer");
            int bookID = Convert.ToInt32(Console.ReadLine());
            //Admin.loaned.Add(new Admin.books(bookID));

            UserMenu();
        }


        public static void ReturnBook()
        {

        }


        public static void LoanedBooks()
        {
            foreach (var item in Admin.loaned)
            {
                Console.WriteLine(item.GetTitle() + " " + item.GetAuthor());
            }
            Console.WriteLine("\nGå bakåt? Tryck Enter");
            Console.ReadLine();
            UserMenu();
        }
    }
}
