using Microsoft.AspNet.Mvc;
using WebApi.Interfaces;
using WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Cache;
using System;
using WebApi.TraceInfo;
namespace WebApi.Controllers
{
    /// api/image?name=Header.Logo&lang=eng
    /// api/image?name=Header*
    /// api/image?name=*
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        public IImage Images { get; set; }
        public ImageController(IImage images){Images = images;}
        public async Task<object> Get([FromQuery]string name, string lang, string cache)
        {
            return await Task.Run(async () => {
                try
                {
                    var keyword = name;
                    var language = (string.IsNullOrWhiteSpace(lang)) ? "eng" : lang;
                    var cacheKey = $"image:{name}:{language}";
                    await AddCorOptions();
                    var isCache = (string.IsNullOrWhiteSpace(cache)) ? "yes" : "no";
                    if (isCache == "no") await CacheMemory.Remove(cacheKey);
                    var jsonResults = await CacheMemory.Get<List<DictionaryItem>>(cacheKey);
                    if (jsonResults != null) return jsonResults;
                    List<DictionaryItem> images = await Images.Get(keyword, language);
                    await CacheMemory.SetAndExpiresDays(cacheKey, images, 1);
                    return images;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("ImageController:Get", ex);
                    return null;
                }
            });
        }
        private async Task AddCorOptions()
        {
            await Task.Run(() =>
            {
                Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
                Response.Headers.Add("Access-Control-Allow-Headers",
                    new[] { "Origin, X-Requested-With, Content-Type, Accept" });
            });
        }
    }
}
