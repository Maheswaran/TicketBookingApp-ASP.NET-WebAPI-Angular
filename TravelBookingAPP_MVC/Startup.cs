using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketBookingApp.Startup))]
namespace TicketBookingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
