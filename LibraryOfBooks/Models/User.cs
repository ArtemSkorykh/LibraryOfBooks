using Microsoft.AspNetCore.Identity;

namespace LibraryOfBooks.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
