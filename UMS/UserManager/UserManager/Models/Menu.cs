using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UserManager.Models
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)] 
        public string MenuText { get; set; }

        [Required]
        [StringLength(400)] 
        public string MenuURL { get; set; }

        public int? ParentId { get; set; }

        public virtual Menu Menu2 { get; set; }

        public int? SortOrder { get; set; }

        public virtual ICollection<Menu> Menu_ParentIds { get; set; }

        public virtual ICollection<MenuPermission> MenuPermission_MenuIds { get; set; }

    }
}
