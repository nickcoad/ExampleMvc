using System.Collections.Generic;
using System.Threading.Tasks;
using MvcExample.Cqrs.Queries.Models;

namespace MvcExample.Cqrs.Queries.Interfaces
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : BaseQuery
    {
        Task<List<TResult>> Handle(TQuery query);
    }
}
