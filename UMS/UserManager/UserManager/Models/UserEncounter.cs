/*list of the multiple encounters that are matched together in the system*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserEncounter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public DateTime EncounterDate { get; set; }

        [StringLength(20)]
        public string Format { get; set; }

        public string Location { get; set; }

        public string Reason { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }



    }
}
