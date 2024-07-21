namespace PlaywrigthSpecFlow.API.Models
{
    public class User
    {
        public string userID { get; set; }

        public string username { get; set; }

        public List<Book> books { get; set; }

        public User()
        {
            books = new List<Book>();
        }
    }

    public class Book
    {
        public string isbn { get; set; }

        public string title { get; set; }

        public string subTitle { get; set; }

        public string author { get; set; }

        public DateTime publish_date { get; set; }

        public string publisher { get; set; }

        public int pages { get; set; }

        public string description { get; set; }

        public string website { get; set; }
    }
}
