using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace DayGetterService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DayGetterService" in both code and config file together.
    public class DayGetter : IDayGetter
    {
        public string GetDayInBulgarian(DateTime date)
        {
            var day = date.ToString("dddd", 
                CultureInfo.CreateSpecificCulture("bg-BG"));

            return day;
        }        
    }
}
