using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(National_Admission_Agency.Startup))]
namespace National_Admission_Agency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
