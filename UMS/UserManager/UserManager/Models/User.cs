using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UserManager.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }


        [Required]
        [StringLength(100)] 
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

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

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [StringLength(50)] 
        public string Email { get; set; }

        public string EmailSignature { get; set; }

        public string About { get; set; }

        [StringLength(100)] 
        public string Website { get; set; }

        [Required]
        public int? GenderId { get; set; }

        public virtual Gender Gender_GenderId { get; set; }

        [Required]
        public int? MaritalStatusId { get; set; }

        public virtual MaritalStatus MaritalStatus_MaritalStatusId { get; set; }

        [StringLength(15)] 
        public string Phone { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public Guid? ParentId { get; set; }

        public virtual User User2 { get; set; }

        [Required]
        public DateTime Dated { get; set; }

        public virtual ICollection<RoleUser> RoleUser_UserIds { get; set; }
        public virtual ICollection<MenuPermission> MenuPermission_UserIds { get; set; }
        public virtual ICollection<UserQualification> UserQualification_UserIds { get; set; }
        public virtual ICollection<UserAddress> UserAddress_UserIds { get; set; }
        public virtual ICollection<UserPhone> UserPhone_UserIds { get; set; }
        public virtual ICollection<UserEmail> UserEmail_UserIds { get; set; }
        public virtual ICollection<UserWorkExperience> UserWorkExperience_UserIds { get; set; }
        public virtual ICollection<UserSkill> UserSkill_UserIds { get; set; }
        public virtual ICollection<UserLanguage> UserLanguage_UserIds { get; set; }
        public virtual ICollection<UserSetting> UserSetting_UserIds { get; set; }
        public virtual ICollection<User> User_ParentIds { get; set; }
        public virtual ICollection<UserMapLocation> UserMapLocation_UserIds { get; set; }

    }
}
