using System.IO;
using WebDbServer;
using WebDbServer.Interfaces;
using WebDbServer.Extensions.Objects;
namespace WebDbServer.Repository
{
    public class AppConfigRepository:IAppConfig
    {
        public dynamic Get()
        {
            var filePath = Path.Combine(Startup.ServerPath, "appsettings.json");
            dynamic results = ObjectExtensions.LoadFileAsType(filePath);
            return results;
        }
    }
}
