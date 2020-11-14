using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.mocks
{
    public class MockUser : IUser
    {
        //Таблица в БД
        private IEnumerable<User> Users
        {
            get => new List<User>()
            {
                new User(0, "NewUser", false),
                new User(1, "Admin", true),
                new User(2, "User", false),
            };
        }

        public User GetUser(int id)
        {
            return Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User GetUser(IServiceProvider provider)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Если пользователь не зарегистрирован "создаем нового"
            int userId = session.GetInt32("UserID") ?? 0;
            return GetUser(userId);
        }
    }
}
