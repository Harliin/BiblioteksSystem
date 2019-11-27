using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekSystem
{
    class MenyClass
    {
        List<UserClass> userList = new List<UserClass>();
        List<BookClass> bookList = new List<BookClass>();

        public void MainMenu()
        {
            ClearConsole();
            Console.WriteLine("[1]Bibliotekarie\n[2]Lånetagare");

            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    {
                        AdminMenu();
                        break;
                    }
                case '2':
                    {
                        break;
                    }
                default:
                    break;
            }
        }

        public void AdminMenu()
        {
            ClearConsole();
            Console.WriteLine("[1]Hantera lånetagare\n[2]Hantera böcker\n[3]Gå tillbaka");
            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    {
                        AdminUserMenu();
                        break;
                    }
                case '2':
                    {
                        AdminBookMenu();
                        break;
                    }
                case '3':
                    {
                        MainMenu();
                        break;
                    }
                default:
                    AdminMenu();
                    break;
            }
        }
        public void AdminUserMenu()
        {
            ClearConsole();
            Console.WriteLine("[1]Lägg till lånetagare\n[2]Ta bort lånetagare\n[3]Visa låntagare\n[4]Gå tillbaka");
            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    {
                        Console.Write("Ange personnummer :");
                        string pn = Console.ReadLine();
                        Console.WriteLine("Ange lösenord, fyra siffror");
                        Console.Write("Ange lösenord:");
                        string pw = UserPasswordChecker();
                        UserClass user = new UserClass(pn, pw);
                        System.AddUser(user);
                        AdminUserMenu();
                        break;
                    }
                case '2':
                    {
                        System.RemoveUser();
                        break;
                    }
                case '3':
                    {
                        System.ShowUsers();
                        break;
                    }
                case '4':
                    {
                        AdminMenu();
                        break;
                    }
                default:
                    {
                        AdminUserMenu();
                        break;
                    }
            }
        }
        public void AdminBookMenu()
        {
            ClearConsole();
        }
        public void UserMenu()
        {
            ClearConsole();

        }
        public string UserPasswordChecker()
        {
            bool check = false;
            string correctPassword = "";
            int counter = 0;
            do
            {
                Console.WriteLine("Ange lösenord");
                string password = Console.ReadLine();

                if (password.Length == 4)
                {
                    foreach (var item in password)
                    {
                        for (int i = 48; i < 58; i++)
                        {                           
                            if (i == (int)item)
                            {
                                correctPassword += item;
                            }
                        }
                    }
                    check = true;
                }
                else
                {
                    Console.WriteLine("Lösenordet måste vara minst fyra siffror.");
                    Console.ReadKey();

                }
            } while (check == false);
            return correctPassword;

        }
        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
