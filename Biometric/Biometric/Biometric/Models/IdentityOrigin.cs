/*The Origin List within the IDML provide Date of Birth (DOB) and Place of Birth (POB) information pertaining to that identity.*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class IdentityOrigin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }


        [StringLength(50)]
        public string UserID { get; set; }

        [StringLength(30)]
        public string SrcName { get; set; }

        public string SrcIdpk { get; set; }

        [StringLength(100)]
        public string SrcConfidence { get; set; }

        [StringLength(30)]
        public string ClassificationString { get; set; }

        [StringLength(30)]
        public string OwnerProducer { get; set; }

        [StringLength(30)]
        public string Dissem { get; set; }

        //DOB, POB
        [StringLength(10)]  
        public string Type { get; set; }

        [StringLength(20)]
        public string Format { get; set; }

        //date of birth
        public DateTime? DOB { get; set; }

        [StringLength(100)]
        public string Street { get; set; }
    
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        public Guid? IdentityId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual Identity Identity_IdentityId { get; set; }

    }
}
