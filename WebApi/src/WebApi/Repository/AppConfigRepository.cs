using System.IO;
using WebApi.Interfaces;
using WebApi.Extensions.Objects;
namespace WebApi.Repository
{
    public class AppConfigRepository:IAppConfig
    {
        public dynamic Get()
        {

            var filePath = Path.Combine(Startup._appEnvironment.ApplicationBasePath, "appsettings.json");
            dynamic results = ObjectExtensions.LoadFileAsType(filePath);
            return results;
        }
    }
}
