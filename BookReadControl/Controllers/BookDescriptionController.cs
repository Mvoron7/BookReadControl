using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Controllers
{
    public class BookDescriptionController : Controller
    {
        private readonly IBooks _books;
        private readonly IBooksTypes _booksTypes;
        private readonly User _user;

        public BookDescriptionController(IServiceProvider provider, IUser user, IBooks books, IBooksTypes types)
        {
            _books = books;
            _booksTypes = types;
            _user = user.GetCurentUser(provider);
        }

        public ViewResult BookDescription(int id)
        {
            Book book = _books.GetBook(id);
            BookType type = _booksTypes.GetBookType(book.BookTypeId);

            ViewBag.User = _user;
            ViewBag.Title = type.Name;
            return View(book);
        }
    }
}
