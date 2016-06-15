using Microsoft.AspNetCore.Builder;
namespace WebUI
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
    }
}
