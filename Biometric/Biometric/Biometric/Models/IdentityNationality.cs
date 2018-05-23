/*This information provides a compiled list of details on the identities Country, Nationalitity, Citizenship, and Ethnicity. This information is pulled from multiple sources*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class IdentityNationality
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

        [StringLength(10)]
        public string CountryCode { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]  
        public string Nationality { get; set; }

        [StringLength(100)]
        public string Citizenship { get; set; }

        [StringLength(100)]
        public string Ethnicity { get; set; }

        [Required]
        public Guid? IdentityId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual Identity Identity_IdentityId { get; set; }

    }
}
