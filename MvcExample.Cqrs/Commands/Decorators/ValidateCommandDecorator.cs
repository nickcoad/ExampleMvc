using System.Threading.Tasks;
using MvcExample.Cqrs.Commands.Exceptions;
using MvcExample.Cqrs.Commands.Validators;

namespace MvcExample.Cqrs.Commands.Decorators
{
    public class ValidateCommandDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : BaseCommand
    {
        private readonly IValidator<TCommand> _validator;
        private readonly ICommandHandler<TCommand> _handler;

        public ValidateCommandDecorator(
            IValidator<TCommand> validator,
            ICommandHandler<TCommand> handler)
        {
            _validator = validator;
            _handler = handler;
        }
        public async Task Handle(TCommand dto)
        {
            var (result, messages) = _validator.Validate(dto);

            // If there's an error, bail out.
            if (!result)
                await Task.FromException(new InvalidCommandException<TCommand>(dto, messages));

            await _handler.Handle(dto);
        }
    }
}
