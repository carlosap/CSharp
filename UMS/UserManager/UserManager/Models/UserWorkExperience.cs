using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserManager
{
    public class UserWorkExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(100)] 
        public string CompanyName { get; set; }

        [StringLength(100)] 
        public string RoleName { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        [StringLength(400)]
        public string JobDescription { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }


    }
}
