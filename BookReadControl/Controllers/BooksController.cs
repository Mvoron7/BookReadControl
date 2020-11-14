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

        public ViewResult BookList()
        {
            ViewBag.User = _user;
            ViewBag.Title = "Литература";
            var books = _books.Books;
            return View(books);
        }
    }
}
