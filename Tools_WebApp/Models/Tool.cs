using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools_WebApp.Models
{
    public class Tool
    {
        public string IdTool { get; set; }

        public string BoschCode { get; set; }

        public string Description { get; set; }

        public string PrimarySupplier { get; set; }

        public string SecondarySupplier { get; set; }

        public int? Quantity { get; set; }

    }
}