using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;
namespace WebApi.Interfaces
{
    public interface IMenu
    {
        Task<IList<Menu>> Get();
    }
}
