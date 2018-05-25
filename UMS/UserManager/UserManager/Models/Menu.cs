using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace UserManager
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        //public Guid? ParentId { get; set; }
        public virtual Menu ReportsTo { get; set; }
    
        [Required]
        [StringLength(100)] 
        public string MenuText { get; set; }

        [Required]
        [StringLength(400)] 
        public string MenuURL { get; set; }

        public int? SortOrder { get; set; }

        public virtual ICollection<Menu> Menu_ParentIds { get; set; }
        public virtual ICollection<MenuPermission> MenuPermission_MenuIds { get; set; }

    }
}
