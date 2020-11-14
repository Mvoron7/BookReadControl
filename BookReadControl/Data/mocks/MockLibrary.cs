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
    public class MockLibrary : ILibrary
    {
        private static Dictionary<string, LibraryToRead> _libraries;

        public MockLibrary()
        {
            _libraries = new Dictionary<string, LibraryToRead>();
        }

        public LibraryToRead GetLibrary(string id)
        {
            if (!_libraries.ContainsKey(id))
                _libraries.Add(id, new LibraryToRead());
            return _libraries[id];
        }
    }
}
