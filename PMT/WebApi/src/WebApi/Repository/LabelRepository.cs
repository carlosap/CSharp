using System.Collections.Generic;
using System.IO;
using WebApi.Model;
using WebApi.Interfaces;
using WebApi.Extensions.Strings;
using System.Threading.Tasks;
using System;
namespace WebApi.Repository
{
    public class LabelRepository: ILabel
    {
        public async Task<List<DictionaryItem>>Get(string keyword, string language)
        {
            return await Task.Run(async () =>
            {
                var results = new List<DictionaryItem>();
                try
                {
                    var filePath = Path.Combine(Startup._appEnvironment.ApplicationBasePath, "Labels", $"labels-{language}.txt");
                    if (!File.Exists(filePath)) return results;
                    if (keyword.Contains(","))
                    {
                        var labels = keyword.Split(',');
                        foreach (var label in labels)
                            results.AddRange(await filePath.GetLabelsByNameAsync(label));
                    }
                    else
                    {
                        results.AddRange(await filePath.GetLabelsByNameAsync(keyword));
                    }
                }
                catch (Exception ex)
                {
                    await TraceInfo.Tracer.Exception("LabelRepository:Get", ex);
                }
                return results;

            });

        }

    }
}

