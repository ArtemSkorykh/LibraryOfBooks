namespace LibraryOfBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }


        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
