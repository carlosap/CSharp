using System;
using System.Diagnostics;
using Microsoft.AspNet.Mvc;
using WebApi.Interfaces;
using System.Collections.Generic;
using WebApi.Model;
using System.Threading.Tasks;
using WebApi.Cache;
namespace WebApi.Controllers
{
    /// api/form?name=checkout
    [Route("api/[controller]")]
    public class FormController : Controller
    {
        public IForm Form { get; set; }
        public FormController(IForm forms){Form = forms;}      
        public async Task<object> Get([FromQuery]string name, string cache)
        {
            return await Task.Run(async () => {
                try
                {
                    var isCache = (string.IsNullOrWhiteSpace(cache)) ? "yes" : "no";
                    if (isCache == "no") await CacheMemory.Remove(name);
                    var jsonResults = await CacheMemory.Get<IList<Form>>(name);
                    if (jsonResults != null) return jsonResults;
                    var form = await Form.Get(name);
                    await CacheMemory.SetAndExpiresDays(name, form, 1);
                    return form;
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                    return null;
                }
            });
        }
    }
}
