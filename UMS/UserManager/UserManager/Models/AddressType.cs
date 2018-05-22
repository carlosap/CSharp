using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UserManager.Models
{
    public class AddressType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)] 
        public string Name { get; set; }
        public virtual ICollection<UserAddress> UserAddress_AddressTypeIds { get; set; }

    }
}
