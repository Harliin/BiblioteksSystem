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
        private static int _idCounter = 1;

        public UserClass(string pn, string password)
        {
            this.PN = pn;
            this.password = password;

            this.ID = _idCounter;
            _idCounter++;
        }
    }
}
