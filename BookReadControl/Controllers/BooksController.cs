using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooks _books;
        private readonly IBooksTypes _types;
        private readonly User _user;

        public BooksController(IServiceProvider provider, IBooks books, IBooksTypes types, IUser users)
        {
            _books = books;
            _types = types;
            _user = users.GetCurentUser(provider);
        }

        [Route("Books/BooksList")]
        [Route("Books/BooksList/{typeName}")]
        public ViewResult BooksList(string typeName)
        {
            BookType type = _types.BookTypes.Where(t => t.Name.ToUpper().Equals(typeName?.ToUpper())).FirstOrDefault();

            ViewBag.User = _user;
            ViewBag.Title = "Литература";
            var books = _books.Books;

            if (type != null)
            {
                ViewBag.Title = type.Name;
                books = _books.Books.Where(b => b.BookTypeId == type.Id).ToList();
            }

            return View(books);
        }
    }
}
