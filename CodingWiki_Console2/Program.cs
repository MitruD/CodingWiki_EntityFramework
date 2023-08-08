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

//GetAllBooks();
//AddBook();
GetBook();

void GetBook()
{
    using var context = new ApplicationDbContext();
    //var books = context.Books.Where(u=>u.ISBN.Contains("12"));
    //var books = context.Books.Where(u=>EF.Functions.Like(u.ISBN, "12%")).Max(u => u.Price);
    //var books = context.Books.Where(u=>EF.Functions.Like(u.ISBN, "12%")).Count();
    //var books = context.Books.Where(u => EF.Functions.Like(u.ISBN, "12%"));
    //var books = context.Books.Where(u => u.Price > 10).OrderBy(u => u.Title).ThenByDescending(u => u.ISBN);
    
    //Pagination Methods
    var books = context.Books.Skip(0).Take(2);
   
    //Console.WriteLine(book.Title + " - " + book.ISBN);
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}
//void GetBook()
//{
//    using var context = new ApplicationDbContext();
//    Book book = context.Books.First();
//    Console.WriteLine(book.Title + " - " + book.ISBN);
//}

//void GetBook()
//{
//    try
//    {
//    using var context = new ApplicationDbContext();
//    var book = context.Fluent_Books.FirstOrDefault();
//    Console.WriteLine(book.Title + " - " + book.ISBN);
//    }catch(Exception e)
//    {

//    }
//}

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