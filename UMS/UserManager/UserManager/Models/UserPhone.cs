using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager.Models
{
    public class UserPhone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(15)] 
        public string PhoneNumber { get; set; }

    }
}
