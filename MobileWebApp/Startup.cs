using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
[assembly: OwinStartup(typeof(MobileWebApp.Startup))]

namespace MobileWebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here          
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
          
            app.MapSignalR();
        }
    }
}