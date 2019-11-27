using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BibliotekSystem
{
    internal static class System
    {
        internal static void AddUser(UserClass user)
        {
            File.AppendAllText(@"User.txt",
                user.ID + "," + user.PN + "," + user.password + "\n");
        }
        internal static void RemoveUser(int idToRemove)
        {
            var file = new List<string>(File.ReadAllLines(@"C:\Users\jonte\Documents\GitHub\BiblioteksSystem\BibliotekSystem\BibliotekSystem\Data\Users.txt"));
            file.RemoveAt(idToRemove);
            File.WriteAllLines(@"C:\Users\jonte\Documents\GitHub\BiblioteksSystem\BibliotekSystem\BibliotekSystem\Data\Users.txt", file.ToArray());
        }

        internal static void ShowUsers()
        {

        }
        
    }
}
