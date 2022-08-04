using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools_WebApp.Commands
{
    public class CreateToolCommandHandler : ICommandHandler<CreateToolCommand>
    {
        private IRepositoryTools _ToolRepository;


        public CreateToolCommandHandler(IRepositoryTools toolRepository)
        {
            // grazie alla dependency injection (realizzata in questo progetto da Autofac) non sei tu a doverti
            // occupare di creare e passare gli oggetti necessari alle classe che le utilizzano

            if (toolRepository == null)
                throw new System.ArgumentNullException("_ToolRepository");

            _ToolRepository = toolRepository;
        }


        public void Handle(CreateToolCommand command)
        {
            // execute command here
            // you can use your repositories
    
            _ToolRepository.Insert(command);
            
        }

    }
}