using System.Threading.Tasks;

namespace MvcExample.Cqrs.Commands.Interfaces
{
    public interface ICommandHandler<in TCommand>
        where TCommand : BaseCommand
    {
        Task Handle(TCommand dto);
    }
}
