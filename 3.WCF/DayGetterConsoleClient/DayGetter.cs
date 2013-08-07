using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayGetterConsoleClient
{
    class DayGetter
    {
        static void Main(string[] args)
        {
            var dayGetter = new ServiceReference1.DayGetterClient();

            var today = dayGetter.GetDayInBulgarian(DateTime.Now);
            Console.WriteLine(today);

            Console.WriteLine("In twenty days : {0}", dayGetter.GetDayInBulgarian(DateTime.Now.AddDays(20)));
        }
    }
}
