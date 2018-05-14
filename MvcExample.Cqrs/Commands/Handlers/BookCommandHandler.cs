using System.Threading.Tasks;
using MvcExample.Cqrs.Commands.Interfaces;
using MvcExample.Cqrs.Commands.Models;
using MvcExample.Data;
using MvcExample.Data.Entities;

namespace MvcExample.Cqrs.Commands.Handlers
{
    public class BookCommandHandler :
        ICommandHandler<CreateBookCommand>,
        ICommandHandler<DeleteBookCommand>
    {
        private readonly DataContext _dbContext;

        public BookCommandHandler(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateBookCommand dto)
        {
            var newBook = new Book
            {
                AuthorId = dto.AuthorId,
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate
            };

            _dbContext.Books.Add(newBook);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Handle(DeleteBookCommand dto)
        {
            var toDelete = new Book {Id = dto.BookId};

            _dbContext.Books.Remove(toDelete);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
