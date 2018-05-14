using System;

namespace MvcExample.Cqrs.Commands.Models
{
    public class DeleteBookCommand : BaseCommand
    {
        public Guid BookId { get; set; }
    }
}
