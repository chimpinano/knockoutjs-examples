using KnockoutJSTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnockoutJSTest.DAL
{
    public class BookInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            var authors = new List<Author>();
            var author2 = new Author
            {
                Biography = "...",
                FirstName = "Tom",
                LastName = "Pom"
            };
            var author3 = new Author
            {
                Biography = "...",
                FirstName = "Superman",
                LastName = "Big"
            };
            var author4 = new Author
            {
                Biography = "...",
                FirstName = "Spiderman",
                LastName = "Small"
            };
            var author5 = new Author
            {
                Biography = "...",
                FirstName = "Batman",
                LastName = "Cool"
            };
            var books = new List<Book>
                {
                new Book {
                    Author = author5,
                    Description = "...",
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51T%2BWt430bL._AA160_.jpg",
                    Isbn = "1491914319",
                    Synopsis = "...",
                    Title = "Knockout.js: Building Dynamic Client-Side Web Applications"
                },
                new Book {
                    Author = author2,
                    Description = "...",
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51AkFkNeUxL._AA160_.jpg",
                    Isbn = "1449319548",
                    Synopsis = "...",
                    Title = "20 Recipes for Programming PhoneGap: Cross-Platform Mobile Development"
                },
                new Book {
                    Author = author3,
                    Description = "...",
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51LpqnDq8-L._AA160_.jpg",
                    Isbn = "1449309860",
                    Synopsis = "...",
                    Title = "20 Recipes for Programming MVC 3: Faster, Smarter Web Development"
                },
                new Book {
                    Author = author4,
                    Description = "...",
                    ImageUrl = "http://ecx.images-amazon.com/images/I/41JC54HEroL._AA160_.jpg",
                    Isbn = "1460954394",
                    Synopsis = "...",
                    Title = "Rapid Application Development With CakePHP"
                }
                };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}