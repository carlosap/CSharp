/*The name list provides detailed names extracted from enrollments pulled-in from multiple sources. 
 * This may contain multiple names and spellings as an individual may provide false names and spelling differences. 
 * Below are two examples of names.
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class IdentityName
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
        public string FullName { get; set; }

        [StringLength(50)]
        public string GivenName { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        public Guid? IdentityId { get; set; }

        public virtual Identity Identity_IdentityId { get; set; }
    }
}
