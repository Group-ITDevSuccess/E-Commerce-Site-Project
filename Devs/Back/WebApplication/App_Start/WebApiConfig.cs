using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using WebApplication.Business;
using WebApplication.Entity;
using WebApplication.Resolvers;

namespace WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web


            // DI:
            UnityContainer unityContainer = new UnityContainer();
            SetDependencies(unityContainer);
            config.DependencyResolver = new UnityResolver(unityContainer);

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void SetDependencies(UnityContainer container)
        {
            container.RegisterType<EntityRepository<Contacts>, ContactsRepository>();
            container.RegisterType<EntityRepository<Brand>, BrandsRepository>();
            container.RegisterType<EntityRepository<Categories>, CategoriesRepository>();
            container.RegisterType<EntityRepository<Stocks>, StocksRepository>();
            container.RegisterType<EntityRepository<Role>, RolesRepository>();
            container.RegisterType<EntityRepository<BankAccount>, BankAccountRepository>();
            container.RegisterType<EntityRepository<Cards>, CardsRepository>();
            container.RegisterType<EntityRepository<CardTypes>, CardTypesRepository>();
            container.RegisterType<EntityRepository<Agence>, AgenceRepository>();
            container.RegisterType<EntityRepository<Users>, UsersRepository>();
        }
    }
}
