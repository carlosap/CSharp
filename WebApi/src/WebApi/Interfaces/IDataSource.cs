using System.Threading.Tasks;
namespace WebApi.Interfaces
{
    public interface IDataSource
    {
        Task<object> Get(string name);
    }
}
