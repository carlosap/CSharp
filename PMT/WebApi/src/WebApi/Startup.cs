using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using WebApi.Interfaces;
using WebApi.Interfaces.Communications;
using WebApi.Repository;

namespace WebApi
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public static IApplicationEnvironment _appEnvironment;
        public static dynamic AppSettings;
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IAppConfig, AppConfigRepository>();
            //services.AddSingleton<IEns210, Ens210Repository>();
            //services.AddSingleton<IiAQCORE, IAQCORERepository>();
            //services.AddSingleton<IStatic, StaticRepository>();
            services.AddSingleton<ICOREALL, COREALLRepository>();
            services.AddSingleton<ISendEmail, SendEmailRepository>();
            //services.AddSingleton<ISendSms, SendSmsRepository>();

        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            IApplicationEnvironment appEnvironment, 
            IAppConfig webappconfig)
        {

            _appEnvironment = appEnvironment;
            AppSettings = webappconfig.Get();
            app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseMvc();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
