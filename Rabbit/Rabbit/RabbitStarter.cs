using Microsoft.Framework.DependencyInjection;
using Rabbit.FileSystems.AppData;
using Rabbit.FileSystems.AppData.Impl;
using Rabbit.FileSystems.Root;
using Rabbit.FileSystems.Root.Impl;
using System;

namespace Rabbit
{
    public class RabbitStarter
    {
        public static IServiceProvider Build()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IAppDataDirectory, AppDataDirectory>();
            serviceCollection.AddScoped<IRootDirectory, RootDirectory>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}