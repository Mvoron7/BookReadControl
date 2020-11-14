using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadControl.Data.Models
{
    /// <summary>
    /// Имеет смысл разнести непосредственно книги
    /// и их описание, как отдельный класс с набором функций для
    /// отображения дополнительной информации.
    /// Например список аналогов, оценки, прочие плашки.
    /// </summary>
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NatureName { get; set; }

        /// <summary>url image</summary>
        public string TitleImg { get; set; }

        /// <summary>International Standard Book Number, по сути еще одни ID</summary>
        public string ISBN { get; set; }

        public ushort Year { get; set; }

        public ushort PageCount { get; set; }

        public int BookTypeId { get; set; }

        #region 
        public ushort ReadingPages { get; set; }

        public decimal ReadingPersent { get => (decimal)ReadingPages / PageCount * 100; }

        public DateTime Readed { get; set; }
        #endregion
    }
}
