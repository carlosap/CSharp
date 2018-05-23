using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserSocialMedia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string SocialMediaName { get; set; }

        [StringLength(50)]
        public string ProfileUrl { get; set; }

        [StringLength(50)]
        public string ProfileImage { get; set; }

        [StringLength(200)]
        public string About { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_IdentityId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
