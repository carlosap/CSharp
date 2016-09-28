//using Microsoft.AspNet.Mvc;
//using System.Threading.Tasks;
//using WebApi.Cache;
//using System;
//using WebApi.TraceInfo;
//using WebApi.Model.Sensors;

//namespace WebApi.Controllers
//{
//    ///SET - > api/setlimit?name=humidity&min=45&max=60&msg=hello
//    [Route("api/[controller]")]
//    public class SetLimitController : Controller
//    {
//        public async Task<object> Get([FromQuery]string name,string min, string max,string msg)
//        {
//            return await Task.Run(async () => {

//                try
//                {
//                    if (name == null) return new[] { "error", "missing name" };
//                    if (max == null) max = "0";
//                    if (min == null) min = "0";
//                    if (msg == null) msg = "";

//                    await AddCorOptions();
//                    var limit = new Limit
//                    {
//                        Name = name,
//                        Max = decimal.Parse(max),
//                        Min = decimal.Parse(min),
//                        Msg = msg
//                    };
//                    await CacheMemory.SetAndExpiresDays(name, limit);
//                    return null;
//                }
//                catch (Exception ex)
//                {
//                    await Tracer.Exception("SetLimitController:Get", ex);
//                    return null;
//                }
//            });
//        }

//        private async Task AddCorOptions()
//        {
//            await Task.Run(() =>
//            {
//                Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
//                Response.Headers.Add("Access-Control-Allow-Headers",
//                    new[] { "Origin, X-Requested-With, Content-Type, Accept" });
//            });
//        }
//    }
//}
