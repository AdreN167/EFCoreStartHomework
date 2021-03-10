using EFCoreStartHomework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreStartHomework.Data
{
    class LibraryContext : DbContext
    {
        public LibraryContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=WW\\MSSQLSERVER2017; Database=EFCoreLibrary; Trusted_Connection=True;");
        }
    }
}
