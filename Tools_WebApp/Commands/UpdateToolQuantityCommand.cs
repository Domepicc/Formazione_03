using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools_WebApp.Commands
{
    public class UpdateToolQuantityCommand : ICommand
    {
        public string ToolId { get; private set; }
        public int? NewQuantity { get; private set; }

        public UpdateToolQuantityCommand(string toolId, int? quantity)
        {
            ToolId = toolId;
            NewQuantity = quantity;
        }
    }
}