using System;
using MvcExample.Domain.Models.Authors;

namespace MvcExample.Domain.Models.Books
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public AuthorDto Author { get; set; }
    }
}
