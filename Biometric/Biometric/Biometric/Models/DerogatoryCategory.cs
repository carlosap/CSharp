using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Biometric
{
    public class DerogatoryCategory
    {
        [Key]
        [Column("Id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("UserID", Order = 1)]
        [StringLength(50)]
        public string UserID { get; set; }

        [Column("SrcName", Order = 2)]
        [StringLength(30)]
        public string SrcName { get; set; }

        [Column("SrcIdpk", Order = 3)]
        public string SrcIdpk { get; set; }

        [Column("SrcConfidence", Order = 4)]
        [StringLength(100)]
        public string SrcConfidence { get; set; }

        [Column("ClassificationString", Order = 5)]
        [StringLength(30)]
        public string ClassificationString { get; set; }

        [Column("OwnerProducer", Order = 6)]
        [StringLength(30)]
        public string OwnerProducer { get; set; }

        [Column("Dissem", Order = 7)]
        [StringLength(30)]
        public string Dissem { get; set; }

        [Required]
        [Column("IdentityDerogatoryId", Order = 8)]
        public Guid? IdentityDerogatoryId { get; set; }
        public virtual IdentityDerogatory IdentityDerogatory_IdentityDerogatoryId { get; set; }

        [Column("Value", Order = 9)]
        public string Value { get; set; }

        [Column("Details", Order = 10)]
        public string Details { get; set; }

        [Required]
        [Column("CreatedDate", Order = 11)]
        public DateTime CreatedDate { get; set; }

        [Column("LastUpdated", Order = 12)]
        public DateTime LastUpdated { get; set; }

    }
}
