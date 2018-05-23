using System;
using System.ComponentModel.DataAnnotations;

namespace UserManager
{
    public class Contact
    {
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

        public int? GenderId { get; set; }
        public virtual Gender Gender_GenderId { get; set; }

        public int? MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus_MaritalStatusId { get; set; }

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

        [StringLength(50)]
        public string City { get; set; }

        public int? StateId { get; set; }
        public virtual State State_StateId { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country_CountryId { get; set; }

        public string WebPage { get; set; }

        public string AvatarProfile { get; set; }

        public string Notes { get; set; }

        public string About { get; set; }

        public DateTime? DoB { get; set; }

    }
}
