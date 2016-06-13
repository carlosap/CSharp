using System;
using Microsoft.AspNet.Mvc;
using System.Diagnostics;
using WebApi.Interfaces;
using System.Collections.Generic;
using WebApi.Model;
using System.Threading.Tasks;
using WebApi.Cache;
namespace WebApi.Controllers
{
    ///api/media?name=header
    [Route("api/[controller]")]
    public class MediaController: Controller
    {
        public IMedia Medias { get; set; }
        public MediaController(IMedia media){ Medias = media;}
        public async Task<object> Get([FromQuery]string name)
        {
            return await Task.Run(async () => {
                try
                {
                    await AddCorOptions();
                    var jsonResults = await CacheMemory.Get<List<Media>>(name);
                    if (jsonResults != null) return jsonResults;
                    var media = await Medias.Get(name);
                    await CacheMemory.SetAndExpiresDays(name, media, 1);
                    return media;
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

