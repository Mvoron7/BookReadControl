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

        public User(int id, string name, bool admin)
        {
            Id = id;
            Name = name;
            Admin = admin;
        }
    }
}
