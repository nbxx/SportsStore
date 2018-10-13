using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Moq;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.Domain.Mock;
using Vic.SportsStore.WebApp.Infrastructure.Abstract;
using Vic.SportsStore.WebApp.Infrastructure.Concrete;

namespace Vic.SportsStore.WebApp
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());

            builder.RegisterInstance<IProductsRepository>(new EFProductRepository())
                .PropertiesAutowired();

            builder.RegisterInstance<IOrderProcessor>(new EmailOrderProcessor(new EmailSettings()));

            builder
                .RegisterInstance<IAuthProvider>(new FormsAuthProvider())
                .PropertiesAutowired();

            builder
                .RegisterType<EFDbContext>()
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}