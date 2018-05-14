using System.Threading.Tasks;
using MvcExample.Data;
using MvcExample.Data.Entities;

namespace MvcExample.Cqrs.Commands
{
    public class CreateDirectorCommand : BaseCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateDirectorCommandHandler : ICommandHandler<CreateDirectorCommand>
    {
        private readonly DataContext _dbContext;

        public CreateDirectorCommandHandler(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateDirectorCommand dto)
        {
            var newDirector = new Director
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            _dbContext.Directors.Add(newDirector);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
