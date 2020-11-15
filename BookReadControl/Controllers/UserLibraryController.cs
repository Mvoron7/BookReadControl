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
        private readonly IUser _users;
        private readonly IServiceProvider _provider;
        private readonly IBooks _books;
        private readonly ILibrary _library;

        public UserLibraryController(IServiceProvider provider, IBooks books, ILibrary library, IUser users)
        {
            _books = books;
            _library = library;
            _provider = provider;
            _users = users;
        }

        public ViewResult BooksList()
        {
            ISession session = _provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            string libraryId = session.GetString("LibraryId") ?? Guid.NewGuid().ToString();
            session.SetString("LibraryId", libraryId);
            LibraryToRead library = _library.GetLibrary(libraryId);

            User user = _users.GetCurentUser(_provider);

            ViewBag.User = user;
            ViewBag.Title = user.Name;
            var books = library.Books;
            return View(books);
        }

        public RedirectToActionResult AddToLibrary(int id)
        {
            ISession session = _provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            string libraryId = session.GetString("LibraryId") ?? Guid.NewGuid().ToString();
            session.SetString("LibraryId", libraryId);

            _library.AddBook(libraryId, _books.GetBook(id));

            return RedirectToAction("BooksList");
        }
    }
}
