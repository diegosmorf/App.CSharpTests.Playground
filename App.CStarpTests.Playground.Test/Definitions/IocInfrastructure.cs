using App.CSharpTests.Playground.Core.WordCount.Infrastructure;
using Autofac;

namespace App.CStarpTests.Playground.Test.Definitions
{
    public class IocInfrastructure : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceWordsFrequency>().AsImplementedInterfaces();
            

            base.Load(builder);
        }
    }
}