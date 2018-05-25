/*user has associated the named individuals with the subject.*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManager
{
    public class UserKnownAssociate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string MiddleName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(20)]
        public string MaritalStatus { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string JobTitle { get; set; }

        [StringLength(15)]
        public string BusinessPhone { get; set; }

        [StringLength(15)]
        public string HomePhone { get; set; }

        [StringLength(15)]
        public string MobilePhone { get; set; }

        [StringLength(15)]
        public string FaxNumber { get; set; }

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

        [StringLength(400)]
        public string WebPage { get; set; }

        [StringLength(400)]
        public string AvatarProfile { get; set; }

        [StringLength(400)]
        public string About { get; set; }

        public DateTime DoB { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

    }
}
