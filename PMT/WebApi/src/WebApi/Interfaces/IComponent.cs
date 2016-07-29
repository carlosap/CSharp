using System.Threading.Tasks;
namespace WebApi.Interfaces
{
    public interface IComponent
    {
        Task<dynamic> GetByName(string compName, bool usecache);        
    }
}

