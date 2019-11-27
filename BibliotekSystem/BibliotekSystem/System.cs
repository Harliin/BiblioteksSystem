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
            File.AppendAllText(@"C:\Users\jonte\Documents\GitHub\BiblioteksSystem\BibliotekSystem\BibliotekSystem\Data\Users.txt",
                user.ID + "," + user.PN + "," + "," + user.password);
        }
        internal static void RemoveUser()
        {

        }

        internal static void ShowUsers()
        {

        }
        
    }
}
