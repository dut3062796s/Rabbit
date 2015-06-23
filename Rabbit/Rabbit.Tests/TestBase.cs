using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rabbit.Tests
{
    [TestClass]
    public abstract class TestBase
    {
        protected ILifetimeScope Container { get; private set; }

        protected TestBase()
        {
            var starter = new Starter();

            starter.RegisterBuilder(Register);

            var container = Container = starter.GetRootContainer();
            var type = GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                if (!container.IsRegistered(propertyType))
                    continue;
                property.SetValue(this, container.Resolve(propertyType), null);
            }
            /*            var kernelBuilder = new KernelBuilder();
                        kernelBuilder.OnStarting(Register);
                        kernelBuilder.UseCaching(c => c.UseMemoryCache());
                        kernelBuilder.UseLogging(c => c.UseNLog());

                        var container = Container = kernelBuilder.Build();
                        var type = GetType();
                        var properties = type.GetProperties();
                        foreach (var property in properties)
                        {
                            var propertyType = property.PropertyType;
                            if (!container.IsRegistered(propertyType))
                                continue;
                            property.SetValue(this, container.Resolve(propertyType), null);
                        }*/
        }

        protected virtual void Register(ContainerBuilder builder)
        {
        }
    }
}