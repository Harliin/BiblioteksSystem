using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekSystem
{
    class BookClass
    {
        public string title { get; set; }
        public string author { get; set; }

        public BookClass(string title, string author)
        {
            this.title = title;
            this.author = author;
        }
    }
}
