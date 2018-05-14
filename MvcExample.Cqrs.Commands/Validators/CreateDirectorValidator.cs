using System.Collections.Generic;
using System.Linq;

namespace MvcExample.Cqrs.Commands.Validators
{
    public class CreateDirectorValidator : IValidator<CreateDirectorCommand>
    {
        public (bool result, List<string> messages) Validate(CreateDirectorCommand dto)
        {
            var messages = new List<string>();

            if (string.IsNullOrEmpty(dto.FirstName))
                messages.Add("First name cannot be empty.");

            if (string.IsNullOrEmpty(dto.LastName))
                messages.Add("Last name cannot be empty.");

            return (messages.Any(), messages);
        }
    }
}
