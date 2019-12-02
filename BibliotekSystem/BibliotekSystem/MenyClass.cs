﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BibliotekSystem
{
    class MenyClass
    {

        public void MainMenu()
        {
            ClearConsole();
            Console.WriteLine("Välkommen till Biblioteket\n");
            Console.WriteLine("Huvudmeny");
            Console.WriteLine("_________\n");
            Console.WriteLine("[1]Bibliotekarie\n[2]Lånetagare");

            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    {
                        ClearConsole();
                        if (CheckAdminPassword())//Password = "admin"
                        {
                            AdminMenu();
                        }
                        else
                        {
                            Console.WriteLine("Fel lösenord!");
                            Console.ReadKey();
                            MainMenu();
                        }
                        break;
                    }
                case '2':
                    {
                        if (File.Exists(@"Users.txt"))
                        {
                            UserMenu();
                        }
                        else
                        {
                            ClearConsole();

                            Console.WriteLine("\nDet finns inga inlagda lånetagare");
                            System.Threading.Thread.Sleep(800);
                            MainMenu();
                        }
                        break;
                    }
                default:
                    {
                        MainMenu();
                        break;
                    }
            }
        }

        public void AdminMenu()
        {
            ClearConsole();
            Console.WriteLine("Bibliotekarie Meny");
            Console.WriteLine("__________________\n");
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
            Console.WriteLine("Bibliotekarie Lånetagare Meny");
            Console.WriteLine("_____________________________\n");
            Console.WriteLine("[1]Lägg till lånetagare\n[2]Ta bort lånetagare\n[3]Visa låntagare\n[4]Gå tillbaka");
            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    {
                        ClearConsole();
                        Console.WriteLine("Lägg till lånetagare");
                        Console.WriteLine("____________________\n");
                        Console.Write("Ange personnummer :");
                        string pn = Console.ReadLine();

                        string pw = UserPasswordChecker();
                        UserClass user = new UserClass(pn, pw);
                        UserClass.AddUser(user);
                        AdminUserMenu();
                        break;
                    }
                case '2':
                    {
                        ClearConsole();
                        Console.WriteLine("Ta bort lånetagare");
                        Console.WriteLine("__________________\n");
                        UserClass.RemoveUser();
                        AdminUserMenu();
                        break;
                    }
                case '3':
                    {
                        ClearConsole();
                        Console.WriteLine("Visa lånetagare");
                        Console.WriteLine("_______________\n");
                        UserClass.ShowUsers();
                        Console.ReadKey();
                        AdminUserMenu();
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
            Console.WriteLine("Bibliotekarie Bok Meny");
            Console.WriteLine("______________________\n");
            Console.WriteLine("[1]Lägg till bok\n[2]Ta bort bok\n[3]Lägg till snuskbok\n[4]Ta bort snuskbok\n[5]Visa böcker\n[6]Gå tillbaka");
            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    {
                        ClearConsole();
                        Console.WriteLine("Lägg till bok");
                        Console.WriteLine("_____________\n");
                        Console.Write("Ange bok namn:");
                        string bookName = Console.ReadLine(); 

                        Console.Write("Ange författare: ");
                        string bookAuthor = Console.ReadLine();
                        BookClass book = new BookClass(bookName, bookAuthor);
                        BookClass.AddBook(book);
                        AdminBookMenu();
                        break;
                    }
                case '2':
                    {
                        ClearConsole();
                        Console.WriteLine("Ta bort bok");
                        Console.WriteLine("___________\n");
                        BookClass.RemoveBook();
                        AdminBookMenu();

                        
                        break;
                    }
                case '3':
                    {
                        ClearConsole();
                        Console.WriteLine("Lägg till snuskbok");
                        Console.WriteLine("_____________\n");
                        Console.Write("Ange bok namn:");
                        string bookName = Console.ReadLine();

                        Console.Write("Ange författare: ");
                        string bookAuthor = Console.ReadLine();
                        DirtyBookClass book = new DirtyBookClass(bookName, bookAuthor);
                        DirtyBookClass.AddDirtyBook(book);
                        AdminBookMenu();
                        break;
                    }
                case '4':
                    {
                        ClearConsole();
                        Console.WriteLine("Ta bort snuskbok");
                        Console.WriteLine("___________\n");
                        DirtyBookClass.RemoveDirtyBook();
                        AdminBookMenu();
                        break;
                    }
                case '5':
                    {
                        ClearConsole();
                        Console.WriteLine("Visa böcker");
                        Console.WriteLine("___________\n");
                        BookClass.ShowBooks();
                        Console.ReadKey();
                        AdminBookMenu();
                        break;
                    }
                case '6':
                    {
                        AdminMenu();
                        break;
                    }
                default:
                    {
                        AdminBookMenu();
                        break;
                    }
            }
        }
        public void UserMenu()
        {
            ClearConsole();
            Console.WriteLine("Lånetagare Meny");
            Console.WriteLine("_______________\n"); ;
            Console.WriteLine("[1]Låna bok\n[2]Låna snuskbok\n[3]Lämna tillbaka bok\n[4]Se kundkorg\n[5]Checka ut böcker\n[6]Gå tillbaka");
            char key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    {
                        ClearConsole();
                        Console.WriteLine("Låna bok");
                        Console.WriteLine("________\n");
                        Console.WriteLine("Här är listan på tillgängliga böcker");
                        Console.WriteLine("____________________________________");
                        UserClass.AddBookToUser();
                        UserMenu();
                        break;
                    }
                case '2':
                    {
                        ClearConsole();
                        bool loginComplete = DirtyBookClass.DirtyLogin();
                        if (loginComplete == true) 
                        {
                            
                            UserClass.AddDirtyBookToUser();
                            
                            
                            //DirtyBookClass.ShowDirtyBooks();
                            
                            UserMenu();
                            break;
                        }
                        else break;
                        
                    }
                case '3':
                    {
                        ClearConsole();
                        Console.WriteLine("Lämna tillbaka bok");
                        Console.WriteLine("__________________\n");
                        
                        UserClass.ReturnBooks();
                        UserMenu();
                        break;
                    }
                case '4':
                    {
                        ClearConsole();
                        Console.WriteLine("Nuvarande böcker");
                        Console.WriteLine("________________\n");
                        Console.WriteLine("Dessa varor finns i din kundkorg");
                        Console.WriteLine("________________________________");
                        UserClass.ShowUserBooks();
                        UserMenu();
                        break;
                    }
                case '5':
                    {
                        ClearConsole();
                        Console.WriteLine("Checkar ut böcker");
                        Console.WriteLine("_________________\n");
                        (bool foundUser, string person) = Checkout.CheckoutUser();
                        if (foundUser == true)
                        {
                            Console.WriteLine("Checkar ut...");
                            Checkout.CompleteCheckout(person);
                        }
                        else
                        {
                            Console.ReadKey();
                            UserMenu();
                        }
                        System.Threading.Thread.Sleep(700);
                        MainMenu();
                        break;
                    }
                case '6':
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
        private bool CheckAdminPassword()
        {
            Console.WriteLine("_________________________");
            Console.Write("\nSkriv in admins lösenord: ");
            string tempPassword = Console.ReadLine();
            if (tempPassword == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
