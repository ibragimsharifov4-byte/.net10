

using Domain.Models;
using Infrastructure.Repositories;

var repo = new BooknestRepository();
var authorRepo = new AuthorRepository();
var genreRepo = new GenreRepository();
while (true)
{
    System.Console.WriteLine("1.Get Books");
    System.Console.WriteLine("2.Add Book");
    System.Console.WriteLine("3.Update Book");
    System.Console.WriteLine("4.Delete Book");
    Console.WriteLine("5.Get Authors");
    Console.WriteLine("6.Add Author");
    Console.WriteLine("7.Update Author");
    Console.WriteLine("8.Delete Author");
    Console.WriteLine("9.Get Genres");
    Console.WriteLine("10.Add Genre");
    Console.WriteLine("11.Update Genre");
    Console.WriteLine("12.Delete Genre");
    System.Console.WriteLine("13.Get Book Amount");
    System.Console.WriteLine("14.Get Author Amount");
    System.Console.WriteLine("15.Get Genre Amount");
    System.Console.WriteLine("16.Get Minimum Published Year By Author");
    System.Console.WriteLine("17.Get Maximum Published Year By Author");
    System.Console.WriteLine("18.Get Minimum Published Year By Genre");
    System.Console.WriteLine("19.Get Maximum Published Year By Genre");
    System.Console.WriteLine("20.Get amount of books by published year");
    System.Console.WriteLine("21.Get amount of books by genre");
    System.Console.WriteLine("==========================");
    var choose = Convert.ToInt32(Console.ReadLine());
    switch (choose)
    {
        case 1:
            {
                var books = repo.GetBooknests();
                foreach (var item in books)
                {
                    System.Console.WriteLine($"Id: {item.Id}");
                    System.Console.WriteLine($"Title: {item.Title}");
                    System.Console.WriteLine($"Create Year {item.CreateYear}");
                    System.Console.WriteLine($"Price: {item.Price}");
                System.Console.WriteLine("==========================");
                }
                break;
            }
        case 2:
            {
            Console.Write("Enter book title: ");
            var title = Console.ReadLine();
            Console.Write("Enter book create year: ");
            var cy = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter book price: ");
            var price = Convert.ToDecimal(Console.ReadLine());
            var book = new Booknest()
            {
                Title = title,
                CreateYear = cy,
                Price = price
            };
            repo.AddBook(book);
            break;
        }

        case 3:
            {
                Console.Write("Enter book id: ");
                var id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new book title: ");
                var title = Console.ReadLine();
                Console.Write("Enter new book create year: ");
                var cy = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new book price: ");
                var price = Convert.ToDecimal(Console.ReadLine());
                var book = new Booknest()
                {
                    Id = id,
                    Title = title,
                    CreateYear = cy,
                    Price = price
                };
                repo.Update(book);
                Console.WriteLine("Book updated successfully!");
                break;
            }

        case 4:
            {
                Console.Write("Enter book id: ");
                var id = Convert.ToInt32(Console.ReadLine());
                repo.Delete(id);
                break;
            }
        case 5:
            {
                var authors = authorRepo.GetAuthors();
                foreach (var item in authors)
                {
                    System.Console.WriteLine($"Id: {item.Id}");
                    System.Console.WriteLine($"Fullname: {item.Fullname}");
                    System.Console.WriteLine($"Country: {item.Country}");
                    System.Console.WriteLine($"Birthdate: {item.Birthdate}");
                    System.Console.WriteLine("==========================");
                }
                break;
            }
        case 6:
            {
                Console.Write("Enter author fullname: ");
                var fullname = Console.ReadLine();
                Console.Write("Enter author country: ");
                var country = Console.ReadLine();
                Console.Write("Enter author birth year: ");
                var birthdate = Convert.ToInt32(Console.ReadLine());
                var author = new Author()
                {
                    Fullname = fullname,
                    Country = country,
                    Birthdate = birthdate
                };
                authorRepo.AddAuthor(author);
                break;
            }
        case 7:
            {
                Console.Write("Enter author id: ");
                var id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new author fullname: ");
                var fullname = Console.ReadLine();
                Console.Write("Enter new author country: ");
                var country = Console.ReadLine();
                Console.Write("Enter new author birth year: ");
                var birthdate = Convert.ToInt32(Console.ReadLine());
                var author = new Author()
                {
                    Id = id,
                    Fullname = fullname,
                    Country = country,
                    Birthdate = birthdate
                };
                authorRepo.UpdateAuthor(author);
                Console.WriteLine("Author updated successfully!");
                break;
            }

        case 8:
            {
                Console.Write("Enter author id: ");
                var id = Convert.ToInt32(Console.ReadLine());
                authorRepo.DeleteAuthor(id);
                break;
            }
        case 9:
            {
                var genres = genreRepo.GetGenres();
                foreach (var item in genres)
                {
                    System.Console.WriteLine($"Id: {item.Id}");
                    System.Console.WriteLine($"Name: {item.Name}");
                    System.Console.WriteLine("==========================");
                }
                break;
            }
        case 10:
            {
                Console.Write("Enter genre name: ");
                var name = Console.ReadLine();
                var genre = new Genre()
                {
                    Name = name
                };
                genreRepo.AddGenre(genre);
                break;
            }
        case 11:
            {
                Console.Write("Enter genre id: ");
                var id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new genre name: ");
                var name = Console.ReadLine();
                var genre = new Genre()
                {
                    Id = id,
                    Name = name
                };
                genreRepo.UpdateGenre(genre);
                Console.WriteLine("Genre updated successfully!");
                break;
            }

        case 12:
            {
                Console.Write("Enter genre id: ");
                var id = Convert.ToInt32(Console.ReadLine());
                genreRepo.DeleteGenre(id);
                break;
            }
        case 13:
            {
                repo.GetBookAmount();
                break;
            }
        case 14:
            {
                authorRepo.GetAuthorsAmount();
                break;
            }
        case 15:
            {
                genreRepo.GetGenresAmount();
                break;
            }
        case 16:
            {
                Console.Write("Enter author id: ");
                var authorId = Convert.ToInt32(Console.ReadLine());
                repo.GetMinPublishedYearByAuthor(authorId);
                break;
            }
        case 17:
            {
                Console.Write("Enter author id: ");
                var authorId = Convert.ToInt32(Console.ReadLine());
                repo.GetMaxPublishedYearByAuthor(authorId);
                break;
            }
        case 18:
            {
                Console.Write("Enter genre id: ");
                var genreId = Convert.ToInt32(Console.ReadLine());
                repo.GetMinPublishedYearByGenre(genreId);
                break;
            }

        case 19:
            {
                Console.Write("Enter genre id: ");
                var genreId = Convert.ToInt32(Console.ReadLine());
                repo.GetMaxPublishedYearByGenre(genreId);
                break;
            }

        case 20:
            {
                Console.Write("Enter published year: ");
                var year = Convert.ToInt32(Console.ReadLine());
                repo.GetAmountByPublishedYear(year);
                break;
            }
        case 21:
            {
                Console.Write("Enter genre id: ");
                var genreId = Convert.ToInt32(Console.ReadLine());
                repo.GetAmountByGenre(genreId);
                break;
            }
    }
}