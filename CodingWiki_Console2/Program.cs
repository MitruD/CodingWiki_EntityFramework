using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



//using (ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if (context.Database.GetPendingMigrations().Count() > 0)
//    { 
//    context.Database.Migrate();
//    }
//}

GetAllBooks();
AddBook();

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}

void AddBook()
{
    Book book = new Book()
    {
        Title = "Test",
        ISBN = "Test",
        Price = 10.23m,
        Publisher_Id = 1
    };

    using var context = new ApplicationDbContext();
    var books = context.Books.Add(book);
    context.SaveChanges();
}