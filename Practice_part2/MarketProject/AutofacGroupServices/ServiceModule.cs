using Autofac;
using MarketProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.AutofacGroupServices
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ProductService>()
            .As<IProductService>()
            .InstancePerLifetimeScope();
        }
    }
}
