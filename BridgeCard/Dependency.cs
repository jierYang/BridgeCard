using System;
using Autofac;
using BridgeCard.Rule;

namespace BridgeCard
{
    public class Dependency  
    {
        public IContainer Container { get; set; }
        
        public Dependency()
        {
            var builder = new ContainerBuilder();  
            builder.RegisterType<Demand>().As<IDemand>();  
          
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces();
            
            Container = builder.Build();
        }
    }  
}