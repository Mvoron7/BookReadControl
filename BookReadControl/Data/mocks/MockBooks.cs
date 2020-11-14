using BookReadControl.Data.Interfaces;
using BookReadControl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.mocks
{
    public class MockBooks : IBooks
    {
        public IEnumerable<Book> Books
        {
            get => new List<Book>()
            {
            // Данные заданы для наглядности, в рабочей версии значения должны заводиться через конструктор.
                new Book()
                {
                    Id = 1,
                    Name = "Микроконтроллеры AVR семейства Classic фирмы ATMEL",
                    NatureName = "Микроконтроллеры AVR семейства Classic фирмы ATMEL",
                    TitleImg = "/img/3PYN-SfKfqs.jpg",
                    ISBN = "9785-97060-260-7",
                    Year = 2018,
                    PageCount = 100,
                    ReadingPages = 100,
                    Readed = DateTime.Parse("01,01,1900"),
                    BookTypeId = 1,
                },
                new Book()
                {
                    Id = 2,
                    Name = "Чистый код. Создание, анализ и рефакторинг",
                    NatureName = "Clean Code. Handbook of Agile Software Craftsmanship",
                    TitleImg = "/img/3PYN-SfKfqs.jpg",
                    ISBN = "978-5-4461-0960-9",
                    Year = 2021,
                    PageCount = 457,
                    ReadingPages = 457,
                    Readed = DateTime.Parse("25, 10, 2020"),
                    BookTypeId = 1,
                },
                new Book()
                {
                    Id = 3,
                    Name = " Интерфейс. Основы проектирования взаимодействия",
                    NatureName = "Подробнее: https://www.labirint.ru/books/642466/",
                    TitleImg = "/img/3PYN-SfKfqs.jpg",
                    ISBN = "978-5-4461-0877-0",
                    Year = 2020,
                    PageCount = 719,
                    ReadingPages = 279,
                    Readed = DateTime.Parse("01, 10, 2020"),
                    BookTypeId = 1,
                },
                new Book()
                {
                    Id = 4,
                    Name = "Совершенный код: Практическое руководство по разработке программного обеспечения",
                    NatureName = "Code complete",
                    TitleImg = "/img/3PYN-SfKfqs.jpg",
                    ISBN = "978-5-9909805-1-8",
                    Year = 2020,
                    PageCount = 841,
                    ReadingPages = 210,
                    Readed = DateTime.Parse("31, 10, 2020"),
                    BookTypeId = 1,
                },
                new Book()
                {
                    Id = 5,
                    Name = "Реактивное программирование с применением RxJava",
                    NatureName = "",
                    TitleImg = "/img/3PYN-SfKfqs.jpg",
                    ISBN = "978-5-97060-496-0",
                    Year = 2017,
                    PageCount = 351,
                    ReadingPages = 0,
                    Readed = DateTime.Parse("01, 01, 1900"),
                    BookTypeId = 1,
                },
                new Book()
                {
                    Id = 6,
                    Name = "WPF windows presentation Foundation в .Net 4.5 с примерами на C# 5.0 для профессионалов",
                    NatureName = "",
                    TitleImg = "/img/3PYN-SfKfqs.jpg",
                    ISBN = "978-5-8459-1854-3",
                    Year = 2017,
                    PageCount = 1014,
                    ReadingPages = 1014,
                    Readed = DateTime.Parse("01, 03, 2020"),
                    BookTypeId = 1,
                },
                new Book()
                {
                    Id = 7,
                    Name = "Linux Карманный справочник",
                    NatureName = "Linux phrasebook",
                    TitleImg = "/img/3PYN-SfKfqs.jpg",
                    ISBN = "978-5-8459-1956-4",
                    Year = 2015,
                    PageCount = 407,
                    ReadingPages = 0,
                    Readed = DateTime.Parse("12, 10, 2020"),
                    BookTypeId = 1,
                }
            };
        }

        public Book GetBook(int id)
        {
            return Books.Where(b => b.Id == id).FirstOrDefault();
        }
    }
}
