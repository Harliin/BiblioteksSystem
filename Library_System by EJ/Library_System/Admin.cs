using System;
using System.Collections.Generic;

namespace Library_System
{
    class Admin
    {
        public static List<Book> books = new List<Book>();
        public static List<User> users = new List<User>();
        public static List<Book> loaned = new List<Book>();

        private string username = "admin";
        private string password = "1234";
        public Admin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public Admin()
        {
        }

        // anropas från Main_Menu.MainMenu() 
        public void Login()
        {
            Console.Clear();
            Console.WriteLine("\nSkriv ditt användernamn: ");
            string inputUsername = Console.ReadLine();
            Console.WriteLine("Ange lösenord: ");
            string inputPassword = Console.ReadLine();

            if (IsLoggedIn(inputUsername, inputPassword) == true)
            {
                AdminMenu();
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
            if (inputName.Equals(username) && inputPass.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Välj ditt val\n");
            Console.WriteLine("1. Registrera ny bok \n2. Registrera ny användare \n0. Logga ut");

            ConsoleKeyInfo key = Console.ReadKey();
            string select = key.KeyChar.ToString();

            if (select == "1" || select == "2" || select == "0")
            {
                switch (select)
                {
                    case "1":
                        RegisterBook();
                        break;
                    case "2":
                        RegisterUser();
                        break;
                    case "0":
                        Console.WriteLine("Vill du logga ut?  y/n");
                        string logout = Console.ReadLine();
                        if (logout == "y")
                        {
                            Main_Menu.MainMenu();
                        }
                        else
                        {
                            AdminMenu();
                        }
                        break;
                }
            }
            else
            {
                Console.Clear();
                AdminMenu();
            }
        }
        public void RegisterBook()
        {
            Console.Clear();
            int id = books.Count + 1;
            Console.WriteLine("Bokens titel: ");
            string title = Console.ReadLine();
            Console.WriteLine("Bokens autor: ");
            string author = Console.ReadLine();

            books.Add(new Book(title, author, id++));
            AdminMenu();
        }
        public void RegisterUser()    // NOT WORKING ---------------------------------
        {
            Console.Clear();
            Console.WriteLine("Användarens usernamn: ");
            string newUser = Console.ReadLine();
            Console.WriteLine("Användarens lösenord:  (för att underlätta mata in fyra sifror)");
            string newPass = Console.ReadLine();

            users.Add(new User(newUser, newPass));

            // uncomment to see all items in the User list
            //foreach (var item in Admin.users)
            //{
            //    Console.WriteLine(item.GetUsername() + " " + item.GetPassword());
            //}
            //Console.ReadLine();

            AdminMenu();
        }
    }
}
