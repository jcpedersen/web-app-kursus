using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCF_Client_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use the 'client' variable to call operations on the service.

            //Creating Proxy for the MyService 
            MyServiceClient client = new MyServiceClient();
            Console.WriteLine("Client calling the service...");
            Console.WriteLine(client.HelloWorld("Ram"));
            Console.Read();


            // Always close the client.
            client.Close();
        }
    }
}
