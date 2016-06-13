using System.IO;
using System.Linq;
using WebApi.Interfaces;
using WebApi.Extensions.Strings;
using System.Threading.Tasks;
namespace WebApi.Repository
{
    public class DataSourceRepository:IDataSource
    {
        public Task<object> Get(string name)
        {
            return Task.Run(() =>
            {
                var results = new object();
                var directoryPath = Path.Combine(Startup._appEnvironment.ApplicationBasePath, "DataSource");
                var filePath = Path.Combine(directoryPath, name + ".js");
                var fileNames = Directory.GetFiles(directoryPath, "*" + name + ".js", SearchOption.AllDirectories);
                if (fileNames.Any(fileName => Path.GetFileNameWithoutExtension(fileName).Equals(name)))
                    results = LoadAsType<object>(name, filePath);
                return results;
            });
        }
        public T LoadAsType<T>(string cachekey, string filePath)
        {
            var json = File.ReadAllText(filePath);
            var obj = json.DeserializeObject<dynamic>();
            return obj;
        }
    }
}
