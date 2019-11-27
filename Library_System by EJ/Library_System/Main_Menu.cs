using System;

namespace Library_System
{
    class Main_Menu
    {
        // anropas från Program.Main()
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nVälkommen till Biblioteket\n");
            Console.WriteLine("_________________________________________");
            Console.WriteLine("1. Logga in som bibliotekare\n2. Logga in som låntagare\n3. Avsluta");

            ConsoleKeyInfo key = Console.ReadKey();
            string select = key.KeyChar.ToString();

            if (select == "1" || select == "2" || select == "0")
            {
                switch (select)
                {
                    case "1":
                        Admin admin = new Admin();
                        admin.Login();
                        break;
                    case "2":
                        User_Menu user = new User_Menu();
                        user.Login();
                        break;
                    case "0":
                        Console.WriteLine("Vill du avsluta?   y/n");
                        ConsoleKeyInfo keyToQuit = Console.ReadKey();
                        string selectQuit = keyToQuit.KeyChar.ToString();
                        if (selectQuit == "y")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                            MainMenu();
                        }
                        break;
                }
            }
            else
            {
                Console.Clear();
                MainMenu();
            }
        }
    }
}
