using Microsoft.Framework.DependencyInjection;
using Rabbit;
using Rabbit.FileSystems.AppData;

namespace Console
{
    public class Program
    {
        public void Main(string[] args)
        {
            var provider=RabbitStarter.Build();

            var appDataDirectory=provider.GetService<IAppDataDirectory>();

            System.Console.WriteLine(appDataDirectory.Exists);
        }
    }
}