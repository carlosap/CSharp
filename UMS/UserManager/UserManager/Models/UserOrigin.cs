/*The Origin List within the IDML provide Date of Birth (DOB) and Place of Birth (POB) information pertaining to that identity.*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserOrigin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [StringLength(10)]  
        public string Type { get; set; }

        [StringLength(20)]
        public string Format { get; set; }

        //date of birth
        public DateTime? DoB { get; set; }

        [StringLength(100)]
        public string Street { get; set; }
    
        [StringLength(100)]
        public string City { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
