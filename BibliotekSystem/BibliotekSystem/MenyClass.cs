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

                        string pw = UserPasswordChecker();
                        UserClass user = new UserClass(pn, pw);
                        DataClass.AddUser(user);
                        AdminUserMenu();
                        break;
                    }
                case '2':
                    {
                        DataClass.RemoveUser();
                        break;
                    }
                case '3':
                    {
                        DataClass.ShowUsers();
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
            Console.WriteLine("[1]Låna bok\n[2]Lämna tillbaka bok\n[3]Se kundkorg\n[4]Checka ut böcker\n[5]Gå tillbaka");
            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    {
                        Console.WriteLine("Här är listan på tillgängliga böcker");
                        Console.WriteLine("____________________________________");
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine("Vilken bok vill du lämna tillbaka?");
                        Console.WriteLine("__________________________________");
                        break;
                    }
                case '3':
                    {
                        Console.WriteLine("Dessa varor finns i din kundkorg");
                        Console.WriteLine("________________________________");
                        break;
                    }
                case '4':
                    {
                        Console.WriteLine("Bearbetar ditt lån...");
                        System.Threading.Thread.Sleep(700);
                        break;
                    }
                case '5':
                    {
                        MainMenu();
                        break;
                    }
                default:
                    {
                        UserMenu();
                        break;
                    }
            }
        }
        public string UserPasswordChecker()
        {
            bool check = false;
            string correctPassword = null;
            int counter = 0;
            do
            {
                Console.Write("Ange lösenord, fyra siffror!: ");
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
                                counter++;
                            }
                        }
                    }
                    if (counter == 4)
                    {
                        check = true;
                    }
                    else
                    {
                        Console.WriteLine("Fel format på lösenordet!");
                        counter = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Lösenordet måste vara minst fyra siffror.");
                    System.Threading.Thread.Sleep(600);

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
