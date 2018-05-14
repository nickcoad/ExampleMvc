using System;

namespace MvcExample.Data.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
