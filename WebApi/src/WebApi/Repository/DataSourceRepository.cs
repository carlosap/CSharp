using System.IO;
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
                var fileName = Path.Combine(directoryPath, name + ".json");
                if(File.Exists(fileName))
                    results = fileName.LoadAsTypeAsync<object>();

                return results;
            });
        }

    }
}
