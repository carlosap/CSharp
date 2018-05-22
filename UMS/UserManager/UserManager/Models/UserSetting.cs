using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserManager.Models
{
    public class UserSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(100)] 
        public string SettingKey { get; set; }

        [Required]
        public string SettingValue { get; set; }

        [StringLength(100)] 
        public string SettingGroup { get; set; }

    }
}
