using System.Collections.Generic;
using System.Threading.Tasks;
using MvcExample.Cqrs.Queries.Models;

namespace MvcExample.Cqrs.Interfaces
{
    public interface IQueryProcessor
    {
        Task<List<TResult>> Query<TQuery, TResult>(TQuery query)
            where TQuery : BaseQuery;
    }
}
