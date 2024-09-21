using LibraryOfBooks.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryOfBooks.Data
{
    public static class DBInitializer
    {
        public static async Task InitializeAsync(LibraryDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await context.Database.EnsureCreatedAsync();

            if (context.Authors.Any() || context.Books.Any())
            {
                return;
            }

            var authors = new List<Author>
            {
                new Author { FirstName = "Фёдор", LastName = "Достоевский", Bio = "Русский писатель." },
                new Author { FirstName = "Лев", LastName = "Толстой", Bio = "Русский писатель." },
                new Author { FirstName = "Антон", LastName = "Чехов", Bio = "Русский писатель." }
            };

            await context.Authors.AddRangeAsync(authors);
            await context.SaveChangesAsync();

            var books = new List<Book>
            {
                new Book { Title = "Преступление и наказание", Genre = "Роман", Publisher = "Издательство А", Year = 1866, AuthorId = authors[0].Id },
                new Book { Title = "Война и мир", Genre = "Роман", Publisher = "Издательство Б", Year = 1869, AuthorId = authors[1].Id },
                new Book { Title = "Чайка", Genre = "Пьеса", Publisher = "Издательство В", Year = 1896, AuthorId = authors[2].Id }
            };

            await context.Books.AddRangeAsync(books);
            await context.SaveChangesAsync();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            var adminUser = new User { UserName = "admin@example.com", Email = "admin@example.com", Year = 2020 };
            var userPassword = "AdminPassword123!";

            var result = await userManager.CreateAsync(adminUser, userPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            var regularUser = new User { UserName = "user@example.com", Email = "user@example.com", Year = 2020 };
            var userResult = await userManager.CreateAsync(regularUser, userPassword);
            if (userResult.Succeeded)
            {
                await userManager.AddToRoleAsync(regularUser, "User");
            }
        }
    }
}