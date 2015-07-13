using Microsoft.AspNet.FileProviders;
using Rabbit.FileSystems.Impl;

namespace Rabbit.FileSystems.Root.Impl
{
    public class RootDirectory : PhysicalDirectory, IRootDirectory
    {
        public RootDirectory() : base("d:\\Rabbit",new PhysicalFileProvider("d:\\").GetDirectoryContents("Rabbit"))
        {
        }
    }
}