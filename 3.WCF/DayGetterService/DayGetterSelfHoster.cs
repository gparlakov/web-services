using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DayGetterService
{
    public class DayGetterSelfHoster
    {
        static void Main()
        {
            Uri uri = new Uri("localhost:9999/dayGetter");
            ServiceHost host = new ServiceHost(typeof(DayGetterService.DayGetter), uri);

            using (host)
            {
                host.Open();

                Console.WriteLine("Press [Enter] to exit");
                Console.ReadLine();
                
            }
        }
    }
}
