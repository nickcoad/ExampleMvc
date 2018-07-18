using System;
using System.Collections.Generic;
using MvcExample.Data.Entities;
using MvcExample.Domain.Interfaces;

namespace MvcExample.Domain.Models.Books
{
    public class BookDto : IMapsFrom<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public List<BookDto> OtherBooksByAuthor { get; set; }
    }
}
