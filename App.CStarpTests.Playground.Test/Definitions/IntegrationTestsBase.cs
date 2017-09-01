using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using NUnit.Framework;

namespace App.CStarpTests.Playground.Test.Definitions
{
    [TestFixture]
    public abstract class BaseIntegrationTests
    {
        [SetUp]
        public virtual void BeforeTest() { }

        [TearDown]
        public virtual void AfterTest(){}

        protected IContainer container;

        protected BaseIntegrationTests()
        {
            IEnumerable<IModule> modulos = new List<IModule> { new IocInfrastructure() };

            Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var builder = new ContainerBuilder();

            foreach (var modulo in modulos)
                builder.RegisterModule(modulo);

            container = builder.Build();
        }
    }
}