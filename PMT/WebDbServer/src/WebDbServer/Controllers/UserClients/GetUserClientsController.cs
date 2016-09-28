using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using WebDbServer.TraceInfo;
using WebDbServer.Model;
namespace WebDbServer.Controllers
{
    /// api/getuserclients?take=2
    [Route("api/[controller]")]
    public class GetUserClientsController : Controller
    {
        private UserClientContext _context;
        public GetUserClientsController(UserClientContext context) { _context = context; }
        public async Task<object> Get([FromQuery]int take)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    object results;
                    await AddCorOptions();
                    using (var context = _context)
                    {
                        results = context.Clients.OrderBy(x => x.DateCreated).ToList().Take(take);
                        if (results == null) return null;

                    }
                    return results;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("GetUserClientController:Get", ex);
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
