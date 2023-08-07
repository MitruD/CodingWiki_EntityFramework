﻿using CodingWiki_DataAccess.Data;
using Microsoft.EntityFrameworkCore;

//using (ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if (context.Database.GetPendingMigrations().Count() > 0)
//    { 
//    context.Database.Migrate();
//    }
//}

GetAllBooks();

void GetAllBooks()
{
    using var context = new ApplicationDbContext();
    var books = context.Books.ToList();
    foreach(var book in books)
    {
        Console.WriteLine(book.Title+ "" +book.ISBN);
    }
}