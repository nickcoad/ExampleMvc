using System.Collections.Generic;

namespace MvcExample.Cqrs.Commands.Validators
{
    public interface IValidator<in TCommand>
        where TCommand : BaseCommand
    {
        (bool result, List<string> messages) Validate(TCommand dto);
    }
}
