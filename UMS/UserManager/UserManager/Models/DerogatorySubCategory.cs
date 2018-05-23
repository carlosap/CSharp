using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserManager
{
    public class DerogatorySubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserDerogatoryId { get; set; }
        public virtual UserDerogatory UserDerogatory_UserDerogatoryId { get; set; }

        public string Value { get; set; }

        public string Details { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
