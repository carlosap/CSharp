using System.Linq;
using System.Collections.Generic;
using System.IO;
using WebApi.Model;
using WebApi.Interfaces;
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
                            results.AddRange(await LoadFromFlatFile(filePath, label));
                    }
                    else
                    {
                        results.AddRange(await LoadFromFlatFile(filePath, keyword));
                    }
                }
                catch (Exception ex)
                {
                    await TraceInfo.Tracer.Exception("LabelRepository:Get", ex);
                }
                return results;

            });

        }
        private async Task<List<DictionaryItem>> LoadFromFlatFile(string filePath, string keyword)
        {
            return await Task.Run(() => {
                List<DictionaryItem> definitionList = new List<DictionaryItem>();
                List<string> lines = File.ReadAllLines(filePath).ToList();
                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line) && (line[0] == '\'')) continue;
                    var commaIndex = line.IndexOf(':');
                    if (commaIndex <= 0) continue;
                    if (commaIndex == line.Length - 1) continue;
                    var name = line.Substring(0, commaIndex);
                    var value = line.Substring(commaIndex + 1, line.Length - commaIndex - 1);
                    if (name.Equals(keyword,StringComparison.CurrentCultureIgnoreCase))
                    {
                        definitionList.Add(new DictionaryItem(name, value));
                        break;
                    }                        
                }
                return definitionList;
            });
        }
    }
}

