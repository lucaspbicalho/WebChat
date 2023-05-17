using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using System;
using WebChat.Interface;
using WebChat.Service;


[assembly: OwinStartup(typeof(WebChat.Startup))]
namespace WebChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            ConfigureAuth(appBuilder);
            appBuilder.MapSignalR();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient(typeof(StooqBotService));
        }
    }
}
