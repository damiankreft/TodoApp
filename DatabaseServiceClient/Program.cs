using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseServiceClient.ServiceReference1;

namespace DatabaseServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create an instance of the WCF proxy.
            DatabaseClient client = new DatabaseClient();

            // Step 2: Call the service operations.
            // Call the Hello service option.
            Console.WriteLine(client.Hello());

            // Step 3: Close the client to gracefully close the connection and clean up resources.
            Console.WriteLine("\nPress <Enter> to terminate the client.");
            Console.ReadLine();
            client.Close();
        }
    }
}
