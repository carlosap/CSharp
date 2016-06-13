using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using WebApi.Interfaces;
using WebApi.Model;
using System.Threading.Tasks;
namespace WebApi.Repository
{
    public class FormRepository : IForm
    {
        public async Task<IList<Form>> Get(string name)
        {
            return await Task.Run(async () =>
            {
                var results = new List<Form>();
                var directoryPath = Path.Combine(Startup._appEnvironment.ApplicationBasePath, "DataSource", "forms");
                var filePath = Path.Combine(directoryPath, name + ".js");
                var fileNames = Directory.GetFiles(directoryPath, name + "*.js", SearchOption.AllDirectories);
                if (fileNames.Any(fileName =>
                {
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    return fileNameWithoutExtension != null && fileNameWithoutExtension.Equals(name);
                }))
                    results = await LoadAsList<Form>(filePath);
                return results;
            });

        }
        public async Task<List<T>> LoadAsList<T>(string filePath)
        {
            return await Task.Run(() =>
            {
                var json = File.ReadAllText(filePath);
                var obj = JsonConvert.DeserializeObject<List<T>>(json);
                return obj;
            });
        }
    }
}

