/*This information provides a compiled list of details on the identities Country, Nationalitity, Citizenship, and Ethnicity. This information is pulled from multiple sources*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserNationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [StringLength(100)]  
        public string Nationality { get; set; }

        [StringLength(100)]
        public string Citizenship { get; set; }

        [StringLength(100)]
        public string Ethnicity { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
