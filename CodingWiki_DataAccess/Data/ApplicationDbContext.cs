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
        public DbSet<Genre> Genres { get; set; }

        //Hardcoding conection string... Conection string = servername = "WIN-3LVU4U8LLOI\SQLEXPRESS"
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=WIN-3LVU4U8LLOI\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5); 
        }

    }
}
