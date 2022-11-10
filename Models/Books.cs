using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebAPI.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
    }
}
