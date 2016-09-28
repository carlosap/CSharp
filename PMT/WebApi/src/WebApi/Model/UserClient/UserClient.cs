using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApi.Model.UserClient
{
    [Table("UserClients")]
    public class UserClient
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool TextEnable { get; set; } = true;
        public bool EmailEnable { get; set; } = true;
        public IList<UserClient> Items { get; set; } = new List<UserClient>();
    }
}


