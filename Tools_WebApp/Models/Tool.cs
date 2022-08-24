using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;
using Xunit.Sdk;

namespace Tools_WebApp.Models
{
    public class Tool
    {
        public string IdTool { get; set; }

        public string BoschCode { get; set; }

        public string Description { get; set; }

        public string PrimarySupplier { get; set; }

        public string SecondarySupplier { get; set; }

        //[RegularExpression("([0-9]*)")]
        public int? Quantity { get; set; }

    }
}