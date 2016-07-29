using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;
namespace WebApi.Interfaces
{
    public interface IForm
    {

        Task<IList<Form>> Get(string name);
    }
}
