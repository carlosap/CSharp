using Microsoft.AspNetCore.Builder;
namespace WebUIReactJs
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
    }
}
