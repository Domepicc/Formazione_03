using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools_WebApp.Commands;
using Autofac;

namespace Tools_WebApp.Commands
{
    public class ScopedCommandBus : ICommandPost
    {
        private readonly string SCOPE_NAME = "CommandScope";
        private IContainer _container;


        public ScopedCommandBus(IContainer container)
        {

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        public void Publish<TCommand>(TCommand command) where TCommand : ICommand
        {
            using (var scope = _container.BeginLifetimeScope(SCOPE_NAME))
            {
                var innerHandler = (ICommandHandler<TCommand>)
                    scope.Resolve(typeof(ICommandHandler<TCommand>));

                if (innerHandler != null)
                {

                    new DiagnosticsCommandHandler<TCommand>(
                        new TransactionalCommandHandler<TCommand>(innerHandler))
                        .Handle(command);

                }
            }
        }
    }
}