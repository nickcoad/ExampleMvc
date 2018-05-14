using System;
using System.Linq;
using System.Threading.Tasks;
using MvcExample.Domain.Models.Books;

namespace MvcExample.Domain.Interfaces
{
    public interface IBookService
    {
        IQueryable<BookDto> QueryBooks();
        Task CreateBook(CreateBookDto dto, Guid userId);
        Task DeleteBook(DeleteBookDto dto, Guid userId);
    }
}
