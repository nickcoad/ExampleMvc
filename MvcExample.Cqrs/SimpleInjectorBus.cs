using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvcExample.Cqrs.Commands;
using MvcExample.Cqrs.Commands.Constants;
using MvcExample.Cqrs.Commands.Interfaces;
using MvcExample.Cqrs.Interfaces;
using MvcExample.Cqrs.Queries;
using SimpleInjector;

namespace MvcExample.Cqrs
{
    public class SimpleInjectorBus : IBus
    {
        private Dictionary<Guid, CommandStatus> _commandLog { get; set; }
        private readonly Container _container;

        public SimpleInjectorBus(Container container)
        {
            _container = container;
        }

        public async Task Command<TCommand>(TCommand command) where TCommand : BaseCommand
        {
            var commandId = Guid.NewGuid();
            _commandLog.Add(commandId, CommandStatus.Running);

            var handler = _container.GetInstance<ICommandHandler<TCommand>>();
            await handler.Handle(command).ContinueWith(task =>
            {
                if (task.IsCompletedSuccessfully)
                    UpdateCommandStatus(commandId, CommandStatus.Success);
                
                if (task.IsFaulted)
                    UpdateCommandStatus(commandId, CommandStatus.Error);
            });
        }

        public async Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : BaseQuery
        {
            throw new NotImplementedException();
        }

        private void UpdateCommandStatus(Guid commandId, CommandStatus status)
        {
            if (_commandLog.ContainsKey(commandId))
            {
                _commandLog[commandId] = status;
            }
        }
    }
}
