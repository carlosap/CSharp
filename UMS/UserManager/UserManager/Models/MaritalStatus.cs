using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Collections.Generic;

namespace UserManager
{
    public class MaritalStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)] 
        public string Name { get; set; }

        public virtual ICollection<User> User_MaritalStatusIds { get; set; }

    }
}
