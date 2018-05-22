using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager.Models
{
    public class RoleUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int? RoleId { get; set; }

        public virtual Role Role_RoleId { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        public virtual User User_UserId { get; set; }

    }
}
