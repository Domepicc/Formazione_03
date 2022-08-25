using DocumentFormat.OpenXml.Vml;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tools_WebApp.Validator
{
    public class NotNegativeNumber : ValidationAttribute
    {


        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            else if (!(value is int))
            {
                return false;
            }
            else
            {
                return (int)value > 0;
            }
        }
    }


}