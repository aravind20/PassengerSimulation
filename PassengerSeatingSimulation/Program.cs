using System;
using Autofac;
using PassengerSeatingSimulation.Service;
using PassengerSeatingSimulation.Service.Interfaces;

namespace PassengerSeatingSimulation
{
    class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<PassengerSeatingService>().As<IPassengerSeatingService>();
            return builder.Build();
        }
        static async System.Threading.Tasks.Task Main(string[] args)
        {
             await CompositionRoot().Resolve<Application>().Run();

        }
    }
}
