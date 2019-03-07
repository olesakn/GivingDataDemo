[assembly: WebActivator.PostApplicationStartMethod(typeof(GivingDataDemo.Web.App_Start.IocConfig), "Initialize")]

namespace GivingDataDemo.Web.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    
    public static class IocConfig
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            // Map services
            container.Register<Core.Services.IBookReviewService, Core.Services.BookReviewService>(Lifestyle.Scoped);
            container.Register<Core.Services.IBookService, Core.Services.BookService>(Lifestyle.Scoped);

            // Map repositories 
            //  NOTE - I didn't bother breaking this out into it's own higher-level project, but
            //         this should be the ONLY place the web project uses a direct reference to repos
            container.Register<Core.Interfaces.IBookReviewRepository, Infrastructure.Repositories.BookReviewRepository>(Lifestyle.Scoped);
        }
    }
}