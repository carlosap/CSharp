using System.Collections.Generic;
using System.IO;
using WebApi.Model;
using WebApi.Interfaces;
using WebApi.Extensions.Strings;
using System.Threading.Tasks;
using System;
namespace WebApi.Repository
{
    public class StaticRepository: IStatic
    {
        public async Task<List<DictionaryItem>>Get(string keyword, string language)
        {
            return await Task.Run(async () =>
            {
                var results = new List<DictionaryItem>();
                try
                {
                    var dirName = Path.Combine(Startup._appEnvironment.ApplicationBasePath, "Views", "Partials", "Static");
                    if (keyword.Equals("*"))
                    {
                        
                        var files = dirName.GetFileNames($"*-{ language}.html");
                        foreach (var file in files)
                            results.AddRange(await file.ReadStaticViewTemplateAsync(file.Replace(dirName, "").Replace($"-{ language}.html", "").Replace("\\", "").Trim()));
                        
                    }
                    else
                    {
                        var filePath = Path.Combine(dirName, $"{keyword}-{language}.html");
                        if (!File.Exists(filePath)) return results;
                        results.AddRange(await filePath.ReadStaticViewTemplateAsync(keyword));
                    }
                }
                catch (Exception ex)
                {
                    await TraceInfo.Tracer.Exception("PageStaticRepository:Get", ex);
                }
                return results;

            });

        }

    }
}

