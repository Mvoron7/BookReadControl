using BookReadControl.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Controllers
{
    public class HomeController : Controller
    {
        private IServiceProvider _provider;
        private IUser _users;
        private ISession _session;

        public HomeController(IUser users, IServiceProvider provider)
        {
            _provider = provider;
            _users = users;
            _session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        }

        public ViewResult Index()
        {
            return View();
        }

        public RedirectToActionResult SetUser(int userId)
        {
            _session.Clear();
            _users.GetUser(userId);
            ISession session = _provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            session.SetInt32("UserId", userId);

            return RedirectToAction("bookList", "Books");
        }
    }
}
