using DemoApplication.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoApplication.WorkerTask
{
    class Program
    {
        private static IMyInterface feedService;


        static void Main(string[] args)
        {

            Console.WriteLine("Task Initiazed!");

            IServiceCollection services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();


            feedService = serviceProvider.GetService<IMyInterface>();

            Console.WriteLine(feedService.Add());

        }
    }
}
