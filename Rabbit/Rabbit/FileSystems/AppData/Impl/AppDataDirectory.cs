using Microsoft.AspNet.FileProviders;
using Rabbit.FileSystems.Impl;

namespace Rabbit.FileSystems.AppData.Impl
{
    public class AppDataDirectory: PhysicalDirectory,IAppDataDirectory
    {
        public AppDataDirectory() : base("d:\\Rabbit\\App_Data",new PhysicalFileProvider("d:\\Rabbit").GetDirectoryContents("App_Data"))
        {
        }
    }
}