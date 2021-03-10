using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreStartHomework.Models
{
    // не придумал ничего лучше
    public class AuthorBook
    {
        public Guid AuthorsId { get; set; }
        public Guid BooksId { get; set; }
    }
}
