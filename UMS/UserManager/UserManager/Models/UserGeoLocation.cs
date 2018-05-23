using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace UserManager
{
    public class UserGeoLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Latitude { get; set; }

        [Required]
        [StringLength(50)]
        public string Longitude { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
