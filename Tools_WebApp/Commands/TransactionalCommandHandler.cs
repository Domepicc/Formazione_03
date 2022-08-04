using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools_WebApp.Commands
{
 
    public class TransactionalCommandHandler<TCommand>
           : ICommandHandler<TCommand> where TCommand : ICommand
    {

        ICommandHandler<TCommand> _innerCommandHandler;

        public TransactionalCommandHandler(ICommandHandler<TCommand> innerCommandHandler)
        {
            if (innerCommandHandler == null)
            {
                throw new ArgumentNullException("innerCommandHandler");
            }

            _innerCommandHandler = innerCommandHandler;
        }

        public void Handle(TCommand command)
        {
            //lalario 08/03/2017  not works with oracle provider
            //var options = new TransactionOptions()
            //{
            //    IsolationLevel = IsolationLevel.ReadCommitted
            //};

            //using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            //{
            _innerCommandHandler.Handle(command);
            //    scope.Complete();
            //}

        }
    }
}
