using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools_WebApp.Commands
{
    public interface ICommandPost
    {
        void Publish<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
