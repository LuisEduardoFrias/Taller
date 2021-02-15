[assembly: WebActivator.PostApplicationStartMethod(typeof(Taller.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Taller.App_Start
{
    using System;
    using System.Configuration;
    using System.Reflection;
    using System.Web.Mvc;
    using AutoMapper;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Taller.ConfigMapper;
    using Taller.Data;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {

            container.Register<TallerDbContext>( () => 
            { 
                return new TallerDbContext(ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString); 
            }, Lifestyle.Scoped);
            
            container.Register<IMapper>(() => { return new MapperConfiguration(confing => confing.AddProfile(new MapperCongfing())).CreateMapper(); }); 

        }
    }
}