using System.Collections.Generic;
using System.IO;
using WebApi.Interfaces;
using WebApi.Model;
using System.Threading.Tasks;
using WebApi.Extensions.Strings;
namespace WebApi.Repository
{
    public class MenuRepository : IMenu
    {
        public async Task<IList<Menu>> Get()
        {
            return await Task.Run(async () =>
            {
                var results = new List<Menu>();
                var directoryPath = Path.Combine(Startup._appEnvironment.ApplicationBasePath, "DataSource");
                var filePath = Path.Combine(directoryPath, "menu.js");
                if (File.Exists(filePath))
                    results = await filePath.LoadAsListTypeAsync<Menu>();

                return results;
            });
        }
    }
}

