using System.Threading.Tasks;
using WebApi.Model;
namespace WebApi.Interfaces
{
    public interface IPage
    {
        Task<Page> Get(string compName);
    }
}

