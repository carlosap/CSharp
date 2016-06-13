using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Model;
namespace WebApi.Interfaces
{
    public interface ILabel
    {
        Task<List<DictionaryItem>> Get(string keyword, string language);
    }
}

