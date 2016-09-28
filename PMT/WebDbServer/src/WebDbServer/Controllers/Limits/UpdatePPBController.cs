using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using WebDbServer.TraceInfo;
using WebDbServer.Model;
namespace WebDbServer.Controllers
{
    /// api/updateppb?name=testbeta123&max=1&min=2&msg=3
    [Route("api/[controller]")]
    public class UpdatePPBController : Controller
    {
        private LimitPPBContext _context;
        public UpdatePPBController(LimitPPBContext context) { _context = context; }
        public async Task<object> Get([FromQuery]string name,string max,string min,string msg)
        {
            if (name == null) name = "TESTBETA123";
            if (max == null) max = "0";
            if (min == null) min = "0";
            if (msg == null) msg = "";
            return await Task.Run(async () =>
            {
                try
                {
                    object results;
                    await AddCorOptions();
                    using (var context = _context)
                    {
                        var limit = context.PPB.FirstOrDefault(x => x.Name.Equals(name));
                        if (limit == null)
                        {
                            var dateCreated = DateTime.Now;
                            limit = new PPB()
                            {
                                Name = name,
                                Low = int.Parse(min),
                                Max = int.Parse(max),
                                Msg = msg,
                                DateCreated = dateCreated,
                                LastUpdate = dateCreated
                            };
                            context.PPB.Add(limit);

                        }
                        else
                        {
                            limit.Name = name;
                            limit.Low = int.Parse(min);
                            limit.Max = int.Parse(max);
                            limit.Msg = msg;
                            limit.LastUpdate = DateTime.Now;
                            context.PPB.Update(limit);
                        }                      
                        await context.SaveChangesAsync();
                        results = limit;
                    }
                    return results;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("UpdateHumidityController:Get", ex);
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
