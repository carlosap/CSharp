using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Biometric
{
    public class IdentityGeoLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? IdentityId { get; set; }
        public virtual Identity Identity_IdentityId { get; set; }

        [Required]
        [StringLength(50)]
        public string Latitude { get; set; }

        [Required]
        [StringLength(50)]
        public string Longitude { get; set; }

    }
}
