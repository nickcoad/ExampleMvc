using System;

namespace MvcExample.Cqrs.Commands.Models
{
    public class CreateBookCommand : BaseCommand
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
