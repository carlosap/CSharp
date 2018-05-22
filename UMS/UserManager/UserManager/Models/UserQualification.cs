using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager.Models
{
    public class UserQualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }

        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(100)] 
        public string Qualification { get; set; }

        [StringLength(10)] 
        public string FromYear { get; set; }

        [StringLength(10)] 
        public string ToYear { get; set; }

        [StringLength(50)] 
        public string BoardUniversity { get; set; }

        [Required]
        [StringLength(50)] 
        public string TotalMarks { get; set; }

        [StringLength(50)] 
        public string OutOfMarks { get; set; }

        [StringLength(50)] 
        public string Percentage { get; set; }

    }
}
