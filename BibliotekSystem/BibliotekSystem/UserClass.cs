using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekSystem
{
    class UserClass
    {
        
        public string pn { get; set; }
        public string password { get; set; }

        public UserClass(string pn, string password)
        {
            this.pn = pn;
            this.password = password;
        }
    }
}
