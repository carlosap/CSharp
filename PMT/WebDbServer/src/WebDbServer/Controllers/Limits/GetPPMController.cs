using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using WebDbServer.TraceInfo;
using WebDbServer.Model;
namespace WebDbServer.Controllers
{
    /// api/getppm?name=TESTBETA123
    [Route("api/[controller]")]
    public class GetPPMController : Controller
    {
        private LimitPPMContext _context;
        public GetPPMController(LimitPPMContext context) { _context = context; }
        public async Task<object> Get([FromQuery]string name)
        {
            if (name == null) name = "TESTBETA123";
            return await Task.Run(async () =>
            {
                try
                {
                    await AddCorOptions();
                    using (var context = _context)
                        return context.PPM.FirstOrDefault(x => x.Name.Equals(name));
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("GetPPMController:Get", ex);
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
