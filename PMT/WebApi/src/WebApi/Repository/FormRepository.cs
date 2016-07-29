using System.Collections.Generic;
using System.IO;
using WebApi.Extensions.Strings;
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
                if (File.Exists(filePath))
                    results = await filePath.LoadAsListTypeAsync<Form>();

                return results;
            });

        }

    }
}

