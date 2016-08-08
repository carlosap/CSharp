using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Interfaces
{
    public interface IiAQCORE
    {
        Task<IAQCORE> Get(string serialNumber, string measurement);


    }
}
