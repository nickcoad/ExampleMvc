using System.Threading.Tasks;
using MvcExample.Cqrs.Commands.Interfaces;
using MvcExample.Cqrs.Commands.Models;
using MvcExample.Data;
using MvcExample.Data.Entities;

namespace MvcExample.Cqrs.Commands.Handlers
{
    public class AuthorCommandHandler :
        ICommandHandler<CreateAuthorCommand>
    {
        private readonly DataContext _dbContext;

        public AuthorCommandHandler(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateAuthorCommand dto)
        {
            var newAuthor = new Author
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            _dbContext.Authors.Add(newAuthor);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Handle(DeleteAuthorCommand dto)
        {
            var newAuthor = new Author
            {
                Id = dto.AuthorId
            };

            _dbContext.Authors.Remove(newAuthor);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
