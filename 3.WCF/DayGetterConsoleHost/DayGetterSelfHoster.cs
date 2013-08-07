using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace DayGetterService
{
    public class DayGetterSelfHoster
    {
        static void Main()
        {
            // if exception - ..has not rights... - go to bin/debug and run as administrator the exe file
            // don't close it and run ClientProject

            Uri uri = new Uri("http://localhost:9999/dayGetter");
            ServiceHost host = new ServiceHost(typeof(DayGetterService.DayGetter), uri);

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            using (host)
            {
                host.Open();

                Console.WriteLine("Press [Enter] to exit");
                Console.ReadLine();
                
            }
        }
    }
}
