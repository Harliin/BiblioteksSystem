using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekSystem
{
    class UserClass
    {
        
        public string PN { get; set; }
        public string password { get; set; }

        public int ID { get; set; }

        public int Privilage { get; set; }
        private static int _idCounter = 1;

        public UserClass(string pn, string password, int privilage)
        {
            this.pn = pn;
            this.password = password;
            this.Privilage = privilage;

            this.ID = _idCounter;
            _idCounter++;
        }
    }
}
