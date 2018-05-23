using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Biometric
{
    public class DerogatorySubCategory
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


        [Required]
        public Guid? IdentityDerogatoryId { get; set; }
        public virtual IdentityDerogatory IdentityDerogatory_IdentityDerogatoryId { get; set; }

        public string Value { get; set; }

        public string Details { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
