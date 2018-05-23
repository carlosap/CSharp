using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace UserManager
{
    public class User : Contact
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

        [Required]
        public bool IsActive { get; set; }

        public int AccessFailedCount { get; set; }

        public bool LockEnabled { get; set; }

        public string LockoutDescription { get; set; }

        public Guid? ParentId { get; set; }
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
