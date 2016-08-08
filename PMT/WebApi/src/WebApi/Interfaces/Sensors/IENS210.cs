using System.Threading.Tasks;
using WebApi.Model;
namespace WebApi.Interfaces
{
    public interface IEns210
    {
        Task<ENS210> Get(string serialNumber, string measurement);
    }
}
