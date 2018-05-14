using System.Collections.Generic;
using MvcExample.Domain.Models.Books;

namespace MvcExample.Web.Models.Books
{
    public class BooksIndexViewModel
    {
        public List<BookDto> Books { get; set; }
    }
}
