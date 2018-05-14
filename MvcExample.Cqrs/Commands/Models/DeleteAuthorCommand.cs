using System;

namespace MvcExample.Cqrs.Commands.Models
{
    public class DeleteAuthorCommand : BaseCommand
    {
        public Guid AuthorId { get; set; }
    }
}
