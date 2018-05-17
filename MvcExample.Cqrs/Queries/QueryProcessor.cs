using System.Collections.Generic;
using System.Threading.Tasks;
using MvcExample.Cqrs.Interfaces;
using MvcExample.Cqrs.Queries.Interfaces;
using MvcExample.Cqrs.Queries.Models;
using SimpleInjector;

namespace MvcExample.Cqrs.Queries
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly Container _container;

        public QueryProcessor(Container container)
        {
            _container = container;
        }

        public async Task<List<TResult>> Query<TQuery, TResult>(TQuery query)
            where TQuery : BaseQuery
        {
            var handler = _container.GetInstance<IQueryHandler<TQuery, TResult>>();
            return await handler.Handle(query).ConfigureAwait(false);
        }
    }
}
