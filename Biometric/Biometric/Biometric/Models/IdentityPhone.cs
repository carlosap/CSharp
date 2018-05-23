using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class IdentityPhone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? IdentityId { get; set; }

        public virtual Identity Identity_IdentityId { get; set; }

        [Required]
        [StringLength(20)] 
        public string PhoneNumber { get; set; }

    }
}
