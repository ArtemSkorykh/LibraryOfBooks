﻿namespace LibraryOfBooks.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        public ICollection<Book>?  Books { get; set; }
    }
}
