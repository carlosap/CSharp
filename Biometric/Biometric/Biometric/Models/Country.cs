using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Biometric
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)] 
        public string Name { get; set; }

        [StringLength(10)] 
        public string CountryCode { get; set; }
        public virtual ICollection<State> State_CountryIds { get; set; }

    }
}
