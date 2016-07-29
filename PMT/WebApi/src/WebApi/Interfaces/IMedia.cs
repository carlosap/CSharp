using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;
namespace WebApi.Interfaces
{
    public interface IMedia
    {
        Task<List<Media>> Get(string compName);
    }
}




