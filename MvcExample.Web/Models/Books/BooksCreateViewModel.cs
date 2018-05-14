using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcExample.Web.Models.Books
{
    public class BooksCreateViewModel
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
