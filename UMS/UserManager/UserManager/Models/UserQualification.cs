using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserQualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(100)] 
        public string Qualification { get; set; }
 
        public DateTime? FromYear { get; set; }

        public DateTime? ToYear { get; set; }

        [StringLength(100)] 
        public string BoardUniversity { get; set; }

        [Required]
        [StringLength(100)] 
        public string TotalMarks { get; set; }

        [StringLength(100)] 
        public string OutOfMarks { get; set; }

        public short Percentage { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
