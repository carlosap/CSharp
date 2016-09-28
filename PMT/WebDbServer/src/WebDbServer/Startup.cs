using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebDbServer.Interfaces;
using WebDbServer.Repository;
using Microsoft.EntityFrameworkCore;
using WebDbServer.Model;

namespace WebDbServer
{
    public class Startup
    {
        public static string ServerPath = string.Empty;
        public static dynamic AppSettings;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
           // var connection = @"Data Source=.;Initial Catalog=PMT;Integrated Security=True";

            var connection = Configuration["DefaultConnection"];
            services
                .AddDbContext<UserClientContext>(options => options.UseSqlServer(connection))
                .AddDbContext<LimitHumidityContext>(options => options.UseSqlServer(connection))
                .AddDbContext<LimitPPMContext>(options => options.UseSqlServer(connection))
                .AddDbContext<LimitPPBContext>(options => options.UseSqlServer(connection))
                .AddDbContext<LimitTemperatureContext>(options => options.UseSqlServer(connection));


            services.AddSingleton<IAppConfig, AppConfigRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAppConfig webappconfig)
        {
            ServerPath = env.ContentRootPath;
            AppSettings = webappconfig.Get();
            app.UseMvc();
        }
    }
}
