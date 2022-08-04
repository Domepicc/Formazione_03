using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Tools_WebApp.Commands
{
    public class DiagnosticsCommandHandler<TCommand>
        : ICommandHandler<TCommand> where TCommand : ICommand
    {

        ICommandHandler<TCommand> _innerCommandHandler;

        public DiagnosticsCommandHandler(ICommandHandler<TCommand> innerCommandHandler)
        {

            if (innerCommandHandler == null)
            {
                throw new ArgumentNullException("innerCommandHandler");
            }
            _innerCommandHandler = innerCommandHandler;
        }

        public void Handle(TCommand command)
        {
            Trace.WriteLine("Before the command");
            _innerCommandHandler.Handle(command);
            Trace.WriteLine("After the command");
        }
    }
}