using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UserManager
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [StringLength(30)]
        public string AppName { get; set; }

        [StringLength(10)] 
        public string UserName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string MiddleName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(20)]
        public string MaritalStatus { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string EmailSignature { get; set; }

        [StringLength(20)]
        public string EmailProvider { get; set; }
    
        [StringLength(50)]
        public string JobTitle { get; set; }

        [StringLength(15)]
        public string BusinessPhone { get; set; }

        [StringLength(15)]
        public string HomePhone { get; set; }

        [StringLength(15)]
        public string MobilePhone { get; set; }

        [StringLength(15)]
        public string FaxNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        public string State { get; set; }


        [StringLength(30)]
        public string Province { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(400)]
        public string WebPage { get; set; }

        [StringLength(400)]
        public string Avatar { get; set; }
        
        [StringLength(400)]
        public string About { get; set; }

        public DateTime? DoB { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public short AccessFailedCount { get; set; }

        public bool LockEnabled { get; set; }

        [StringLength(400)]
        public string LockoutDescription { get; set; }

        public virtual User ReportsTo { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

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
        public virtual ICollection<UserGeoLocation> UserGeopLocation_UserIds { get; set; }

    }
}
