using BookReadControl.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions options) : base(options) { }
        public AppDBContent() { }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> Types { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<LibraryToRead> Libraries { get; set; }
    }
}
