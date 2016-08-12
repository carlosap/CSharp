using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebApi.Cache;
using WebApi.TraceInfo;
using WebApi.Interfaces.Communications;
namespace WebApi.Controllers
{
    //api/sendemail?emailto=perezca6576@yahoo.com&emailfrom=spartanjs@gmail.com&emailsubject=this is a test&emailtext=hello&emailattachment=&emailtype=&cache=no
    [Route("api/[controller]")]
    public class SendEmailController : Controller
    {
        public ISendEmail Email { get; set; }
        public SendEmailController(ISendEmail email) { Email = email; }

        public async Task<object> Get([FromQuery] string emailto, 
            string emailfrom, 
            string emailsubject,
            string emailtext,
            string emailattachment, 
            string emailtype,
            string cache)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    if (emailto == null) return new[] { "status", "need emailto" };
                    if (emailfrom == null) return new[] { "status", "need emailfrom" };
                    if (emailsubject == null) return new[] { "status", "need emailsubject" };
                    if (emailtext == null) return new[] { "status", "need emailtext" };
                    var cacheKey = $"email:{emailfrom}:{emailsubject.Trim().Replace(" ", "").ToLower()}";
                    if (cache != null)if (cache == "no") await CacheMemory.Remove(cacheKey);                                                                            
                    var jsonResults = await CacheMemory.Get<object>(cacheKey);
                    if (jsonResults != null) return new[] { "status", "No eamil not sent. Waiting for cache to expired" };
                    await AddCorOptions();
                    await Email.Send(emailto, emailfrom, emailsubject, emailtext);
                    var results = new [] { "status", "OK" };
                    await CacheMemory.SetAndExpiresSeconds(cacheKey, results, 10);
                    return results;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("SendEmailController:Get", ex);
                    return null;
                }
            });
        }

        private async Task AddCorOptions()
        {
            await Task.Run(() =>
            {
                Response.Headers.Add("Access-Control-Allow-Origin", new[] {"*"});
                Response.Headers.Add("Access-Control-Allow-Headers",
                    new[] {"Origin, X-Requested-With, Content-Type, Accept"});
            });
        }
    }
}
