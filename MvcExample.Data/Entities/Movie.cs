using System;

namespace MvcExample.Data.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Guid DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
