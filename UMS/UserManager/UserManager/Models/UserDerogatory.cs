/*The Biometric Watchlist. This information provides detailed information on when first nominated, to approval date of nomination, along with categorical details and regions.*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserDerogatory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [StringLength(100)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Region { get; set; }

        public string Source { get; set; }

        public string Justification { get; set; }

        public string NominatorGroup { get; set; }

        public string NominationDate { get; set; }

        public string ApprovalDate { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
