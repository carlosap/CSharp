using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [StringLength(20)]
        public string Type { get; set; }


        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(20)]
        public string State { get; set; }

        [StringLength(30)]
        public string Province { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }


    }
}
