using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Name of the property will be the table name
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Publisher> Publishers{ get; set; }
        public DbSet<SubCategory> SubCategories{ get; set; }

        //Hardcoding conection string... Conection string = servername = "WIN-3LVU4U8LLOI\SQLEXPRESS"
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=WIN-3LVU4U8LLOI\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            //method 1
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId=1, Title="Mythos", ISBN="123", Price=10.99m},
                new Book { BookId=2, Title="On Writing", ISBN="123d", Price=9.99m}
                );
            //method 2
            var bookList = new Book[]
            {
                new Book { BookId=3, Title="Homo Deus", ISBN="1453", Price=10.99m},
                new Book { BookId=4, Title="Sapiens", ISBN="6543d", Price=9.99m}
            };

            modelBuilder.Entity<Book>().HasData(bookList);
        }

    }
}
