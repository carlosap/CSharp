using System;
using System.Diagnostics;
using Microsoft.AspNet.Mvc;
using WebApi.Interfaces;
using WebApi.Cache;
using System.Threading.Tasks;
namespace WebApi.Controllers
{
    /// api/datasource?name=uiconfig
    [Route("api/[controller]")]
    public class DataSourceController : Controller
    {
        public DataSourceController(IDataSource datasource) { DataSource = datasource;}
        public IDataSource DataSource { get; set; }
        public async Task<object> Get([FromQuery]string name, string cache)
        {
           return await Task.Run(async () => {
                 try
                 {
                   await AddCorOptions();
                   var isCache = (string.IsNullOrWhiteSpace(cache)) ? "yes" : "no";
                   if (isCache == "no") await CacheMemory.Remove(name);
                   var jsonResults = await CacheMemory.Get<object>(name);
                     if (jsonResults != null) return jsonResults;
                     var datasource = await DataSource.Get(name);
                     await CacheMemory.SetAndExpiresDays(name, datasource, 1);
                     return datasource;
                 }
                 catch (Exception ex)
                 {
                     Trace.TraceError(ex.ToString());
                     return Json(new object());
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
