using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using DatabaseServiceLib;

namespace DatabaseServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/DatabaseService/");

            // Step 2: Create ServiceHost instance.
            ServiceHost selfHost = new ServiceHost(typeof(DatabaseService), baseAddress);

            try
            {
                // Step 3: Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IDatabase), new WSHttpBinding(), "DatabaseService");

                // Step 4: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5: Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                // Close the ServiceHost to stop the service.
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occured: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
