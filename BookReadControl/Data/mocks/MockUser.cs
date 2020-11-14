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
                new User(0, "NewUser", false, "/img/1439970506_901940678.jpg"),
                new User(1, "Admin", true, "/img/1440434403_197979955.jpg"),
                new User(2, "User", false, "/img/1455321158194326515.jpg"),
            };
        }

        public User GetUser(int id)
        {
            return Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User GetCurentUser(IServiceProvider provider)
        {
            ISession session = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Если пользователь не зарегистрирован "создаем нового"
            int userId = session.GetInt32(Constants.UserId) ?? 0;
            return GetUser(userId);
        }
    }
}
