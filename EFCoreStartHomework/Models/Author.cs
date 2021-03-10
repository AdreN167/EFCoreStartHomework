using System.Collections.Generic;

namespace EFCoreStartHomework.Models
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}