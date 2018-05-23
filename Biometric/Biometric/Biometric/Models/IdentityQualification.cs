using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class IdentityQualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        public Guid? IdentityId { get; set; }
        public virtual Identity Identity_IdentityId { get; set; }

        [Required]
        [StringLength(100)] 
        public string Qualification { get; set; }

        [StringLength(10)] 
        public string FromYear { get; set; }

        [StringLength(10)] 
        public string ToYear { get; set; }

        [StringLength(50)] 
        public string BoardUniversity { get; set; }

        [Required]
        [StringLength(50)] 
        public string TotalMarks { get; set; }

        [StringLength(50)] 
        public string OutOfMarks { get; set; }

        [StringLength(50)] 
        public string Percentage { get; set; }

    }
}
