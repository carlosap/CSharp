using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                var fileNames = Directory.GetFiles(directoryPath, "*.js", SearchOption.AllDirectories);
                if (fileNames.Any(fileName =>
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    return fileNameWithoutExtension != null && fileNameWithoutExtension.Equals("menu");
                }))
                    results = await LoadAsList<Menu>(filePath);
                return results;
            });

        }
        public Task<List<T>> LoadAsList<T>(string filePath)
        {
            return Task.Run(() => {
                var json = File.ReadAllText(filePath);
                var obj = json.DeserializeObject<List<T>>();
                return obj;
            });
        }
    }
}

