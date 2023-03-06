using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

[assembly: OwinStartup(typeof(WebApplication.App_Start.StartUp))]
namespace WebApplication.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            UnityContainer unityContainer = new UnityContainer();
            //setDependencies(unityContainer);
            //ConfigureOAuth(app, unityContainer);
        }
    }
}