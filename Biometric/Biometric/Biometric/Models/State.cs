using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biometric
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int? CountryId { get; set; }
        public virtual Country Country_CountryId { get; set; }

        [StringLength(100)] 
        public string Name { get; set; }

    }
}
