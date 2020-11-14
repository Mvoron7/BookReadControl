using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Models
{
    public class User
    {
        public int Id { get; }

        public string Name { get; }

        private bool Admin { get; }

        public bool IsAdmin { get => Admin; }

        public string Avatar { get; }

        public User(int userId, string name, bool admin, string avatar)
        {
            Id = userId;
            Name = name;
            Admin = admin;
            Avatar = avatar;
        }
    }
}
