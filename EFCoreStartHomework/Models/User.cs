using System.Collections.Generic;

namespace EFCoreStartHomework.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
        public bool IsDebtor { get; set; }
    }
}
