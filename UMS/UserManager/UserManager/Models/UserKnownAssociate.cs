/*user has associated the named individuals with the subject.*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserKnownAssociate : Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public string AssociateDescription { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }



    }
}
