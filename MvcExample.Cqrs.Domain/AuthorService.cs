using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MvcExample.Cqrs.Commands.Interfaces;
using MvcExample.Cqrs.Commands.Models;
using MvcExample.Cqrs.Interfaces;
using MvcExample.Data;
using MvcExample.Domain.Interfaces;
using MvcExample.Domain.Models.Authors;

namespace MvcExample.Cqrs.Domain
{
    public class AuthorService : IAuthorService
    {
        private readonly ICommandHandler<CreateAuthorCommand> _createAuthorHandler;
        private readonly ICommandHandler<DeleteAuthorCommand> _deleteAuthorHandler;

        public AuthorService(
            ICommandHandler<CreateAuthorCommand> createAuthorHandler,
            ICommandHandler<DeleteAuthorCommand> deleteAuthorHandler)
        {
            _createAuthorHandler = createAuthorHandler;
            _deleteAuthorHandler = deleteAuthorHandler;
        }

        public async Task CreateAuthor(CreateAuthorDto dto, Guid userId)
        {
            var cmd = new CreateAuthorCommand
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            await _createAuthorHandler.Handle(cmd);
        }

        public async Task DeleteAuthor(DeleteAuthorDto dto, Guid userId)
        {
            var cmd = new DeleteAuthorCommand
            {
                AuthorId = dto.AuthorId
            };

            await _deleteAuthorHandler.Handle(cmd);
        }
    }
}
