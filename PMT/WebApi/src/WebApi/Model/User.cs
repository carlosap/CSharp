using System;
namespace WebApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool TextEnable { get; set; } = true;
        public bool EmailEnable { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
