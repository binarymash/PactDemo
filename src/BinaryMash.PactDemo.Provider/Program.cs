using System;
using Microsoft.Owin.Hosting;

namespace BinaryMash.PactDemo.Provider
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUri = "http://localhost:8080";

            Console.WriteLine("Starting web server");
            WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
            Console.ReadLine();
        }
    }
}
