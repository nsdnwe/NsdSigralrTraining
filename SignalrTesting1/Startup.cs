using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

// Install-Package Microsoft.Owin.Cors

[assembly: OwinStartup(typeof(SignalrTesting1.Startup))]

namespace SignalrTesting1 {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            var config = new HubConfiguration();
            config.EnableJSONP = true;
            app.MapSignalR(config);
        }
    }
}
