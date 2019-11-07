using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AirlineApplication.Core.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return(isValid);
        }
       
    }
}