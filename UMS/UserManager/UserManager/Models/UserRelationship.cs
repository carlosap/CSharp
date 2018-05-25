/*The PhysicalDescriptionList details physical traits about an identity. These details include; Height, Weight, Eye Color, Hair Color, Gender, and Skin Color. One example has been provided below.*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserRelationship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }  //BUSINESS ASSOCIATE

        [StringLength(100)]
        public string Name { get; set; }       //AHMAD IBRAHIM AL AHMAD

        [StringLength(100)]
        public string Justification { get; set; }  //CEXC-IZ-CASE-7935-06"

        [StringLength(400)]
        public string Description { get; set; }  //body tag

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }

}
