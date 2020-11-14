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
    public class UserLibraryController : Controller
    {
        private readonly User _user;
        private readonly LibraryToRead _library;
        private readonly IBooks _books;

        public UserLibraryController(IServiceProvider provider, IUser users, IBooks books, ILibrary library)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            string libraryId = session.GetString("LibraryId") ?? Guid.NewGuid().ToString();
            session.SetString("LibraryId", libraryId);

            _books = books;
            _user = users.GetCurentUser(provider);
            _library = library.GetLibrary(libraryId);
        }

        public ViewResult BooksList()
        {
            ViewBag.User = _user;
            ViewBag.Title = _user.Name;
            var books = _library.Books;
            return View(books);
        }

        public RedirectToActionResult AddToLibrary(int id)
        {
            _library.AddBook(_books.GetBook(id));

            return RedirectToAction("BooksList");
        }
    }
}
