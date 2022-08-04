using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools_WebApp.Commands
{
    public class DeleteToolCommand :ICommand
    {
        public string IdTool { get; private set; }

        public DeleteToolCommand(string id)
        {
            IdTool = id;
        }

    }
}