using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using WebDbServer.TraceInfo;
using WebDbServer.Model;
namespace WebDbServer.Controllers
{
    /// api/deleteuserclient?email=cperez@gmail.com
    [Route("api/[controller]")]
    public class DeleteUserClientController : Controller
    {
        private UserClientContext _context;
        public DeleteUserClientController(UserClientContext context) { _context = context; }
        public async Task<object> Get([FromQuery]string email)
        {           
            if (email == null) email = string.Empty;
            return await Task.Run(async () =>
            {
                try
                {
                    object results;
                    await AddCorOptions();
                    using (var context = _context)
                    {
                        var user = context.Clients.Where(x => x.Email.Equals(email));
                        if (user == null) return null;
                        context.Clients.RemoveRange(user);
                        await context.SaveChangesAsync();
                        results = context.Clients.OrderBy(x => x.DateCreated).ToList().Take(20);
                    }
                    return results;
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("DeleteUserClientController:Get", ex);
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
