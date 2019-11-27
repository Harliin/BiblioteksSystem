namespace Library_System
{
    class Book
    {
        private string title;
        private string author;
        private int id;
        public Book(string title, string author, int id)
        {
            this.title = title;
            this.author = author;
            this.id = id;
        }
        public string GetTitle()
        {
            return title;
        }
        public string GetAuthor()
        {
            return author;
        }
        public int GetID()
        {
            return id;
        }
    }
}
