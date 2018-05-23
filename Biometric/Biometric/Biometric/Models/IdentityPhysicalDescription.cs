/*The PhysicalDescriptionList details physical traits about an identity. These details include; Height, Weight, Eye Color, Hair Color, Gender, and Skin Color. One example has been provided below.*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class IdentityPhysicalDescription
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
        public Guid? IdentityId { get; set; }
        public virtual Identity Identity_IdentityId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }  //Height, Weight, EyeColor, HairColor...

        public string Format { get; set; }       //Inches, Pounds etc.

        public string Description { get; set; }
    
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
