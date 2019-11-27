/* 
 * Library System v 1.0
 * 
 * Elchin J.
 * elchinoj08@gmail.com
 * 2019-11-27 
 */



namespace Library_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // När programmet startar adderas admins uppgifter och flera böcker i lista
            Admin.users.Add(new User("user1", "1111"));
            Admin.books.Add(new Book("The Godfather", "Mario Puzo", 1));
            Admin.books.Add(new Book("The ABC Murder", "Agatha Christie", 2));
            Admin.books.Add(new Book("Jane Eyre", "Charlotte Bronte", 3));
            Admin.books.Add(new Book("The Little Mermaid", "Hans Christian Andersen", 4));
            Admin.books.Add(new Book("Snabba Cash", "Jens Lapidus", 5));
            Admin.books.Add(new Book("It", "Stephen King", 6));
            Admin.books.Add(new Book("Harry Potter", "J. K. Rowling", 7));
            Admin.books.Add(new Book("Shutter Island", "Dennis Lehane", 8));
            Admin.books.Add(new Book("Idiot", "Fyodor Dostoyevsky", 9));
            Admin.books.Add(new Book("Don Quixote", "Miguel de Cervantes", 10));
            Admin.books.Add(new Book("Hamlet", "William Shakespeare", 11));
            Admin.books.Add(new Book("The Odyssey", "Homer", 12));


            // Anropas MainMenu 
            Main_Menu.MainMenu();
        }
    }
}
