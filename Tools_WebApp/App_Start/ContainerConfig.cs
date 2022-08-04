using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Tools_WebApp.Models;
using Tools_WebApp.Queries;
using Tools_WebApp.Controllers;
using Tools_WebApp.Commands;
using Tools_WebApp.Events;
using Tools_WebApp.IRepositories;


namespace Tools_WebApp.App_Start
{
    public class ContainerConfig
    {
        static IContainer _container;

        public static IContainer Build()
        {
            var containerBuilder = new ContainerBuilder();

            var assemblies = new Assembly[]
            {
                typeof(ContainerConfig).Assembly,
                typeof(IQuery<Tool>).Assembly,
                typeof(Query).Assembly,

            };

            containerBuilder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces();

            containerBuilder.RegisterAssemblyTypes(typeof(IQuery<Tool>).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            containerBuilder.RegisterApiControllers(assemblies);

            containerBuilder.RegisterControllers(assemblies);




            containerBuilder.Register(c =>
            {
                return new ScopedCommandBus(_container);
            }).As<ICommandPost>();



            _container = containerBuilder.Build();

            Events.Events.Register(@event =>
            {
                var handleType = typeof(IEventHandler<>)
                    .MakeGenericType(@event.GetType());

                var handlers = typeof(IEnumerable<>)
                    .MakeGenericType(handleType);

                var scope = _container.BeginLifetimeScope("EventHandlers");
                var result = scope.Resolve(handlers);

                return new DisposableEventsHolder((IEnumerable<IEventHandler>)result, scope);

            });

            return _container;
        }
    }


}
    
