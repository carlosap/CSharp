/*The name list provides detailed names extracted from enrollments pulled-in from multiple sources. 
 * This may contain multiple names and spellings as an individual may provide false names and spelling differences. 
 * Below are two examples of names.
*/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(50)]
        public string GivenName { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
