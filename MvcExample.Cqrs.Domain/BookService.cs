using System;
using System.Threading.Tasks;
using MvcExample.Cqrs.Commands.Interfaces;
using MvcExample.Cqrs.Commands.Models;
using MvcExample.Domain.Interfaces;
using MvcExample.Domain.Models.Books;

namespace MvcExample.Cqrs.Domain
{
    public class BookService : IBookService
    {
        private readonly ICommandHandler<CreateBookCommand> _createBookHandler;
        private readonly ICommandHandler<DeleteBookCommand> _deleteBookHandler;

        public BookService(
            ICommandHandler<CreateBookCommand> createBookHandler,
            ICommandHandler<DeleteBookCommand> deleteBookHandler)
        {
            _createBookHandler = createBookHandler;
            _deleteBookHandler = deleteBookHandler;
        }
        
        public async Task CreateBook(CreateBookDto dto, Guid userId)
        {
            var cmd = new CreateBookCommand
            {
                AuthorId = dto.AuthorId,
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate
            };

            await _createBookHandler.Handle(cmd);
        }

        public async Task DeleteBook(DeleteBookDto dto, Guid userId)
        {
            var cmd = new DeleteBookCommand
            {
                BookId = dto.BookId
            };

            await _deleteBookHandler.Handle(cmd);
        }
    }
}
