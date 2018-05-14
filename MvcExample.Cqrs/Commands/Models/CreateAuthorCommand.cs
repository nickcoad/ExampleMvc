namespace MvcExample.Cqrs.Commands.Models
{
    public class CreateAuthorCommand : BaseCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
