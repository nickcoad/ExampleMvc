using System;

namespace MvcExample.Domain.Models.Books
{
    public class CreateBookDto
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
