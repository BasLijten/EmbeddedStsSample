using System.IdentityModel.Tokens;
using System.ServiceModel.Security;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.WsFederation;
using Owin;

[assembly: OwinStartup(typeof(EmbeddedStsOWIN.Startup))]
namespace EmbeddedStsOWIN
{    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseWsFederationAuthentication(
                new WsFederationAuthenticationOptions
                {
                    MetadataAddress = "http://localhost:29702/FederationMetadata",                    
                    Wtrealm = "urn:SupaDoopaRealm",       
                    Wreply             = "http://localhost:16635/"
                }
            );

        }
    }
}