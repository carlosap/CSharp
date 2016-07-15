using Microsoft.AspNetCore.Builder;

namespace WebUI
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            SocketServer.Listener(5001);
            app.UseStaticFiles();
            

            
        }
    }
}
