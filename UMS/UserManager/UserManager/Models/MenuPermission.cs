using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserManager.Models
{
    public class MenuPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MenuId { get; set; }

        public virtual Menu Menu_MenuId { get; set; }

        [Required] 
        public int? RoleId { get; set; }

        public virtual Role Role_RoleId { get; set; }

        public Guid? UserId { get; set; }

        public virtual User User_UserId { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsCreate { get; set; }
 
        public bool? IsRead { get; set; }

        public bool? IsUpdate { get; set; }

        public bool? IsDelete { get; set; }

    }
}
