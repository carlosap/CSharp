/*The PhysicalDescriptionList details physical traits about an identity. These details include; Height, Weight, Eye Color, Hair Color, Gender, and Skin Color. One example has been provided below.*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserPhysicalDescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }  //Height, Weight, EyeColor, HairColor...

        [StringLength(15)]
        public string Format { get; set; }       //Inches, Pounds etc.

        [StringLength(15)]
        public string Description { get; set; }   //5 , 145

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
