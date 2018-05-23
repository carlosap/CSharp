using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Biometric
{
    public class IdentityLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid? IdentityId { get; set; }
        public virtual Identity Identity_IdentityId { get; set; }

        [Required]
        public int? LanguageId { get; set; }
        public virtual Language Language_LanguageId { get; set; }

    }
}
