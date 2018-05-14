using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvcExample.Cqrs.Commands;
using MvcExample.Cqrs.Queries;

namespace MvcExample.Cqrs.Interfaces
{
    public interface IBus
    {
        Task Command<TCommand>(TCommand command)
            where TCommand : BaseCommand;


        Task<TResult> Query<TQuery, TResult>(TQuery query)
            where TQuery : BaseQuery;
    }
}
