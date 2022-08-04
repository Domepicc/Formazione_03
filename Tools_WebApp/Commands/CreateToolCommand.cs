using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools_WebApp.Models;


namespace Tools_WebApp.Commands
{
    public class CreateToolCommand :ICommand
    {
        public string IdTool { get; private set; }
        public string BoschCode { get; set; }
        public string Description { get; set; }
        public string PrimarySupplier { get; set; }
        public string SecondarySupplier { get; set; }
        public int? Quantity { get; private set; }

        public CreateToolCommand(Tool tool)
        {
            IdTool = tool.IdTool;
            BoschCode = tool.BoschCode;
            Description = tool.Description;
            PrimarySupplier = tool.PrimarySupplier;
            SecondarySupplier = tool.SecondarySupplier;
            Quantity = tool.Quantity;
        }

    }
}