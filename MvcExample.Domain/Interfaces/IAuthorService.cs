using System;
using System.Linq;
using System.Threading.Tasks;
using MvcExample.Domain.Models.Authors;

namespace MvcExample.Domain.Interfaces
{
    public interface IAuthorService
    {
        Task CreateAuthor(CreateAuthorDto dto, Guid userId);
        Task DeleteAuthor(DeleteAuthorDto dto, Guid userId);
    }
}
