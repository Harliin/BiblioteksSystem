using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;

namespace BibliotekSystem
{
    class Checkout
    {
        internal static (bool, string) CheckoutUser()
        {
            
            if (File.Exists(@"Users.txt"))
            {
                var file = new List<string>(File.ReadAllLines(@"Users.txt"));

                Console.Write("Skriv in ditt personnummer:");
                string tempPN = Console.ReadLine();

                Console.Write("Skriv in lösenordet: ");
                string tempPW = Console.ReadLine();
                foreach (var person in file)
                {
                    if (person.Substring(0, 11) == tempPN)
                    {
                        if (person.Substring(12) == tempPW)
                        {
                            return (true,person);
                        }
                        else
                        {
                            Console.WriteLine("Fel användarnamn eller lösenord!");
                            Thread.Sleep(1500);
                            return (false, string.Empty);
                        }
                            
                    }
                }
                return (false, string.Empty);
            }
            else
            {
                Console.WriteLine("finns inga registrerade lånetagare");
                return (false, string.Empty);
            }
        }

        internal static void CompleteCheckout(string person)
        {
            if (!File.Exists(@"CurrentLoans.txt"))
            {
                File.WriteAllText(@"CurrentLoans.txt", "");
            }
            if (!File.Exists(@"ShoppingBasket.txt"))
            {
                Console.WriteLine("Du har inte valt några böcker!");
            }
            else
            {
                var tempLoans = new List<string>(File.ReadAllLines(@"CurrentLoans.txt"));
                tempLoans.Add(person + "," + File.ReadAllText(@"ShoppingBasket.txt"));
                File.WriteAllLines(@"CurrentLoans.txt", tempLoans.ToArray());
                File.Delete(@"ShoppingBasket.txt");
            }
        }
    }
}
