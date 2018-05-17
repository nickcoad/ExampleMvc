using System.Collections.Generic;
using System.Linq;
using MvcExample.Cqrs.Commands.Models;

namespace MvcExample.Cqrs.Commands.Validators
{
    public class AlwaysValidValidator<TCommand> : IValidator<TCommand>
        where TCommand : BaseCommand
    {
        public (bool result, List<string> messages) Validate(TCommand dto)
        {
            return (true, new List<string>());
        }
    }
}
