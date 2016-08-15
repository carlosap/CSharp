using System.Threading.Tasks;
using WebApi.Model;
namespace WebApi.Interfaces
{
    public interface ICOREALL
    {
        Task<COREALL> Get(string serialNumber, string measurement);
    }
}
