using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using System;
using WebApi.Interfaces.UserClients;
using WebApi.TraceInfo;
namespace WebApi.Controllers
{
    /// api/adduserclient?firstname=carlos&lastname=perez&email=cperez@gmail.com&tel=1234&emailenable=true&textenable=false
    [Route("api/[controller]")]
    public class AddUserClientController : Controller
    {
        public IUserClient Clients { get; set; }
        public AddUserClientController(IUserClient clients){ Clients = clients;}

        public async Task<object> Get([FromQuery]string firstname, string lastname, string email, string tel, bool emailenable = true, bool textenable = true)
        {
            if (firstname == null) throw new ArgumentNullException(nameof(firstname));
            return await Task.Run(async () => {
                try
                {
                    await AddCorOptions();
                    await Clients.Add(firstname, lastname, email, tel, emailenable, textenable);
                    return new[] { "AddUserClient", email };
                }
                catch (Exception ex)
                {
                    await Tracer.Exception("LabelController:Get", ex);
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
