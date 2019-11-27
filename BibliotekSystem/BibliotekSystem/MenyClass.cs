using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekSystem
{
    class MenyClass
    {
        List<UserClass> userList = new List<UserClass>();


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
            Console.WriteLine("[1]Lägg till lånetagare\n[2]Ta bort lånetagare\n[3]Ändra uppgifter på lånetagare\n[4]Gå tillbaka");
            char key = Console.ReadKey().KeyChar;

            switch (key)
            {
                case '1':
                    {
                        Console.Write("Ange personnummer :");
                        string pn = Console.ReadLine();
                        Console.WriteLine("Ange lösenord, fyra siffror");
                        Console.Write("Ange lösenord:");
                        string pw = PasswordChecker(Console.ReadLine());
                        Console.Write("Ange Privilegie: ");
                        int privilage = int.Parse(Console.ReadLine());
                        userList.Add(new UserClass(pn, pw, privilage));
                        AdminUserMenu();
                        break;
                    }
                case '2':
                    {
                        break;
                    }
                case '3':
                    {
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
        public string PasswordChecker(string pw)
        {
            string password = "";
            if (pw.Length < 4 && pw.Length > 4)
            {
                Console.WriteLine("Lösenorder måste vara fyra siffror.");

            }
            else
            {
                foreach (var item in pw)
                {
                    for (int i = 48; i < 58; i++)
                    {
                        if (i == (int)item)
                        {
                            password += item;
                        }
                    }
                }
            }
            return password;
        }
        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
