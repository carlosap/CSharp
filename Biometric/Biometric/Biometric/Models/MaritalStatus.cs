using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Biometric
{
    public class MaritalStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(30)] 
        public string Name { get; set; }

        public virtual ICollection<Identity> Identity_MaritalStatusIds { get; set; }

    }
}
