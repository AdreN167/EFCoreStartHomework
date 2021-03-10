using System.Collections.Generic;

namespace EFCoreStartHomework.Models
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public ICollection<Author> Authors { get; set; }
        public bool Status { get; set; }
    }
}