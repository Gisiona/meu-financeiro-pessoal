using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OEconomicoPessoal.Startup))]
namespace OEconomicoPessoal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
