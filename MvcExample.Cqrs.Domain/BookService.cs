using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore.Storage;
using MvcExample.Cqrs.Commands.Models;
using MvcExample.Cqrs.Interfaces;
using MvcExample.Data;
using MvcExample.Data.Entities;
using MvcExample.Domain.Interfaces;
using MvcExample.Domain.Models.Books;

namespace MvcExample.Cqrs.Domain
{
    public class BookService : IBookService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BookService(IBus bus, IMapper mapper, DataContext context)
        {
            _bus = bus;
            _mapper = mapper;
            _context = context;
        }

        public IQueryable<BookDto> QueryBooks()
        {
            return _context.Books.ProjectTo<BookDto>(_mapper.ConfigurationProvider);
        }

        public async Task CreateBook(CreateBookDto dto, Guid userId)
        {
            var cmd = new CreateBookCommand
            {
                AuthorId = dto.AuthorId,
                Title = dto.Title,
                ReleaseDate = dto.ReleaseDate
            };

            await _bus.Command(cmd);
        }

        public async Task DeleteBook(DeleteBookDto dto, Guid userId)
        {
            var cmd = new DeleteBookCommand
            {
                BookId = dto.BookId
            };

            await _bus.Command(cmd);
        }
    }
}
