using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class IdentityAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? IdentityId { get; set; }
        public virtual Identity User_UserId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int? AddressTypeId { get; set; }
        public virtual AddressType AddressType_AddressTypeId { get; set; }

    }
}
