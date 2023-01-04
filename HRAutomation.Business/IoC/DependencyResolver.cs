using Autofac;
using AutoMapper;
using HRAutomation.Business.AutoMapper;
using HRAutomation.Business.Services.AdminService;
using HRAutomation.DataAccess.Abstract;
using HRAutomation.DataAccess.EntityFramework.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.Business.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminRepo>().As<IAdminRepo>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeRepo>().As<IEmployeeRepo>().InstancePerLifetimeScope();
            builder.RegisterType<AdminService>().As<IAdminService>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg => 
            {
                cfg.AddProfile<Mapping>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
