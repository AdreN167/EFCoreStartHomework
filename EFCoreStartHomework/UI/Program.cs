using EFCoreStartHomework.Data;
using EFCoreStartHomework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFCoreStartHomework.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>();
            var authors = new List<Author>();
            var users = new List<User>();

            var firstAuthor = new Author
            {
                Name = "Александр Пушкин"
            };

            var firstBook = new Book
            {
                Name = "Евгений Онегин",
                Status = false,
                Authors = new List<Author> { firstAuthor }
            };

            var secondBook = new Book
            {
                Name = "Повести Белкина",
                Status = true,
                Authors = new List<Author> { firstAuthor }
            };

            firstAuthor.Books = new List<Book> { firstBook };

            var user = new User
            {
                Name = "Киркоров Филипп",
                Books = new List<Book> { firstBook },
                IsDebtor = true
            };

            books.Add(firstBook);
            books.Add(secondBook);
            authors.Add(firstAuthor);
            users.Add(user);

            firstAuthor = new Author
            {
                Name = "Эндрю Троелсен"
            };

            var secondAuthor = new Author
            {
                Name = "Филипп Джепикс"
            };

            firstBook = new Book
            {
                Name = "Язык программирования C# и платформы .NET и .NET Core",
                Status = false,
                Authors = new List<Author> { firstAuthor, secondAuthor }
            };


            firstAuthor.Books = new List<Book>() { firstBook };
            secondAuthor.Books = new List<Book>() { firstBook };

            user = new User
            {
                Name = "Воробушкин Петр",
                Books = new List<Book> { firstBook },
                IsDebtor = true
            };

            authors.Add(firstAuthor);
            authors.Add(secondAuthor);
            books.Add(firstBook);
            users.Add(user);

            firstAuthor = new Author
            {
                Name = "Николай Гоголь"
            };

            firstBook = new Book
            {
                Name = "Ревизор",
                Status = false,
                Authors = new List<Author> { firstAuthor }
            };

            secondBook = new Book
            {
                Name = "Мертвые души",
                Status = false,
                Authors = new List<Author> { firstAuthor }
            };

            firstAuthor.Books = new List<Book>() { firstBook, secondBook };

            user = new User
            {
                Name = "Горохов Михаил",
                Books = new List<Book> { firstBook, secondBook },
                IsDebtor = true
            };

            authors.Add(firstAuthor);
            books.Add(firstBook);
            books.Add(secondBook);
            users.Add(user);

            using (var context = new LibraryContext())
            {
                context.Books.AddRange(books);
                context.Authors.AddRange(authors);
                context.Users.AddRange(users);
                context.SaveChanges();

                foreach (var dbUser in context.Users)
                {
                    if (dbUser.IsDebtor)
                    {
                        Console.WriteLine($"[{dbUser.Id}] {dbUser.Name}");
                    }
                }
                Console.WriteLine();

                var thirdBookId = Guid.Parse("BCC67795-A9FD-489A-847F-A432046439F6");
                foreach (var dbBook in context.Books.Include(dbBook => dbBook.Authors))
                {
                    foreach (var dbAuthor in dbBook.Authors)
                    {
                        if (thirdBookId == dbBook.Id)
                        {
                            Console.WriteLine($"[{dbAuthor.Id}] {dbAuthor.Name}");
                        }
                    }
                }
                Console.WriteLine();

                foreach (var dbBook in context.Books)
                {
                    if (dbBook.Status)
                    {
                        Console.WriteLine($"[{dbBook.Id}] {dbBook.Name}");
                    }
                }
                Console.WriteLine();

                var secondUser = context.Users.Find(Guid.Parse("66378099-58FB-457B-935A-E1C6A89F375E"));
                foreach (var dbBook in secondUser.Books)
                {
                    Console.WriteLine($"[{dbBook.Id}] {dbBook.Name}");
                }
                Console.WriteLine();

                foreach (var dbUser in context.Users)
                {
                    if (dbUser.IsDebtor)
                    {
                        dbUser.IsDebtor = false;
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
