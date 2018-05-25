using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserManager
{
    public class MenuPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        public Guid? MenuId { get; set; }
        public virtual Menu Menu_MenuId { get; set; }

        [Required] 
        public Guid? RoleId { get; set; }
        public virtual Role Role_RoleId { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsCreate { get; set; }
 
        public bool? IsRead { get; set; }

        public bool? IsUpdate { get; set; }

        public bool? IsDelete { get; set; }

    }
}
