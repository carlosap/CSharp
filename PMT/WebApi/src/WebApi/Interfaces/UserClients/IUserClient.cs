using System.Threading.Tasks;
using WebApi.Model.UserClient;

namespace WebApi.Interfaces.UserClients
{
    public interface IUserClient
    {
        Task Add(string firstName, string lastName, string email, string tel, bool emailEnable = true, bool textEnable = true);
        Task Update(string firstName, string lastName, string email, string tel, bool emailEnable = true, bool textEnable = true);
        Task<UserClient> GetUserByEmail(string email);
        Task Delete(string email);

    }
}


