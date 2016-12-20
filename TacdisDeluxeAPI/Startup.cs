using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TacdisDeluxeAPI.Startup))]

namespace TacdisDeluxeAPI
{
    public partial class Startup
    {
        public static object PublicClientId { get; internal set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
