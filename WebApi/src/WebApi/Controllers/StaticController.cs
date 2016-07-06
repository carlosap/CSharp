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
    /// api/static?name=*
    /// /api/static?name=contact
    [Route("api/[controller]")]
    public class StaticController : Controller
    {
        public IStatic Pages { get; set; }
        public StaticController(IStatic pages){Pages = pages;}
        public async Task<object> Get([FromQuery]string name, string lang, string cache)
        {
            return await Task.Run(async () => {
                try
                {
                    var keyword = name;
                    var language = (string.IsNullOrWhiteSpace(lang)) ? "eng" : lang;
                    var cacheKey = $"static:{name}:{language}";
                    await AddCorOptions();
                    var isCache = (string.IsNullOrWhiteSpace(cache)) ? "yes" : "no";
                    if (isCache == "no") await CacheMemory.Remove(cacheKey);
                    var jsonResults = await CacheMemory.Get<List<DictionaryItem>>(cacheKey);
                    if (jsonResults != null) return jsonResults;
                    List<DictionaryItem> pages = await Pages.Get(keyword, language);
                    await CacheMemory.SetAndExpiresDays(cacheKey, pages, 1);
                    return pages;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("PageStaticController:Get", ex);
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
