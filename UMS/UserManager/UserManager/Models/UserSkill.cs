using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(100)] 
        public string SkillName { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
