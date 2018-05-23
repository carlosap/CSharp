/*The identifier list provides identification numbers (IDs) that have been pulled out of multiple datasets enabling a high-level of analysis to be conducted on identities. These ID numbers can be GUIDs, TCNS, CAIs, ISNs,*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class IdentityIdentifier
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

        [StringLength(50)]  
        public string Type { get; set; }

        public string IdentificationNumber { get; set; }

        [Required]
        public Guid? IdentityId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public virtual Identity Identity_IdentityId { get; set; }

    }
}
