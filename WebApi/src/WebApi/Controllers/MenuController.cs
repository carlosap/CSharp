using WebApi.Interfaces;
using Microsoft.AspNet.Mvc;
using WebApi.Model;
using WebApi.Cache;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebApi.TraceInfo;
namespace WebApi.Controllers
{
    /// api/menu
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        public IMenu Menu { get; set; }
        public MenuController(IMenu menus){Menu = menus;}     
        public async Task<object> Get()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await AddCorOptions();
                    var jsonResults = await CacheMemory.Get<IList<Menu>>("menu");
                    if (jsonResults != null) return jsonResults;
                    var menu = await Menu.Get();
                    await CacheMemory.SetAndExpiresDays("menu", menu, 1);
                    return menu;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("MenuController:Get", ex);
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
