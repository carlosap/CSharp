using System;
using Microsoft.AspNet.Mvc;
using WebApi.Interfaces;
using System.Diagnostics;
using WebApi.Model;
using System.Threading.Tasks;
using WebApi.Cache;
namespace WebApi.Controllers
{
    ///api/page?name=menu
    [Route("api/[controller]")]
    public class PageController : Controller
    {
        public IPage Page { get; set; }
        public PageController(IPage page){Page = page;} 
        public async Task<object> Get([FromQuery]string name)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await AddCorOptions();
                    var jsonResults = await CacheMemory.Get<Page>(name);
                    if (jsonResults != null) return jsonResults;
                    var page = await Page.Get(name);
                    await CacheMemory.SetAndExpiresDays(name, page, 1);
                    return page;
                }
                catch (Exception ex)
                {
                    Trace.TraceError((ex.ToString()));
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

