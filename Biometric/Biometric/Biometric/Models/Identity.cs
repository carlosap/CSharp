using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Biometric
{
    public class Identity
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
        [StringLength(100)] 
        public string IdentityName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)] 
        public string MiddleName { get; set; }

        [Required]
        [StringLength(100)] 
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string ProfilePicture { get; set; }

        public string About { get; set; }

        public string URI { get; set; }

        public string USPerson { get; set; }

        public int ATPScore { get; set; }

        [Required]
        public int? GenderId { get; set; }
        public virtual Gender Gender_GenderId { get; set; }

        //one-to-one relationship with MaritalStatus class
        [Required]
        public int? MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus_MaritalStatusId { get; set; }

        public Guid? ParentId { get; set; }
        public virtual Identity Identity2 { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }


        public virtual ICollection<IdentityQualification> IdentityQualification_IdentityIds { get; set; }
        public virtual ICollection<IdentityAddress> IdentityAddress_IdentityIds { get; set; }
        public virtual ICollection<IdentityPhone> IdentityPhone_IdentityIds { get; set; }
        public virtual ICollection<IdentityEmail> IdentityEmail_IdentityIds { get; set; }
        public virtual ICollection<IdentityWorkExperience> IdentityWorkExperience_IdentityIds { get; set; }
        public virtual ICollection<IdentitySkill> IdentitySkill_IdentityIds { get; set; }
        public virtual ICollection<IdentityLanguage> IdentityLanguage_IdentityIds { get; set; }
        public virtual ICollection<IdentityAttribute> IdentityAttribute_IdentityIds { get; set; }
        public virtual ICollection<Identity> Identity_ParentIds { get; set; }
        public virtual ICollection<IdentityGeoLocation> IdentityGeoLocation_IdentityIds { get; set; }
        public virtual ICollection<IdentityOrigin> IdentityOrigin_IdentityIds { get; set; }
        public virtual ICollection<IdentityAttachment> IdentityAttachment_IdentityIds { get; set; }
        public virtual ICollection<IdentityComment> IdentityComment_IdentityIds { get; set; }
        public virtual ICollection<IdentityEncounter> IdentityEncounter_IdentityIds { get; set; }
        public virtual ICollection<IdentityIdentifier> IdentityIdentifier_IdentityIds { get; set; }
        public virtual ICollection<IdentityKnownAssociate> IdentityKnownAssociate_IdentityIds { get; set; }
        public virtual ICollection<IdentityDerogatory> IdentityDerogatory_IdentityIds { get; set; }
        public virtual ICollection<IdentityName> IdentityName_IdentityIds { get; set; }
        public virtual ICollection<IdentityNationality> IdentityNationality_IdentityIds { get; set; }
        public virtual ICollection<IdentityPhysicalDescription> IdentityPhysicalDescription_IdentityIds { get; set; }
        public virtual ICollection<IdentityRelationship> IdentityRelationship_IdentityIds { get; set; }
        public virtual ICollection<IdentitySocialMedia> IdentitySocialMedia_IdentityIds { get; set; }

    }
}
