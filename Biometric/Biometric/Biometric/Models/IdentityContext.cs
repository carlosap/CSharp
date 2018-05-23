using Microsoft.EntityFrameworkCore;
namespace Biometric
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options): base(options){}
        public IdentityContext() { }

		public virtual DbSet<Identity> Identities { get; set; }
		public virtual DbSet<Gender> Genders { get; set; }
		public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
		public virtual DbSet<IdentityQualification> IdentityQualifications { get; set; }
		public virtual DbSet<IdentityLanguage> IdentityLanguages { get; set; }
		public virtual DbSet<IdentitySkill> IdentitySkills { get; set; }
		public virtual DbSet<IdentityWorkExperience> IdentityWorkExperiences { get; set; }
		public virtual DbSet<IdentityEmail> IdentityEmails { get; set; }
		public virtual DbSet<IdentityPhone> IdentityPhones { get; set; }
		public virtual DbSet<IdentityAddress> IdentityAddresss { get; set; }
		public virtual DbSet<Language> Languages { get; set; }
		public virtual DbSet<AddressType> AddressTypes { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<State> States { get; set; }
		public virtual DbSet<IdentityGeoLocation> IdentityGeoLocations { get; set; }
        public virtual DbSet<IdentityOrigin> IdentityOrigins { get; set; }
        public virtual DbSet<IdentityNationality> IdentityNationalities { get; set; }
        public virtual DbSet<IdentityName> IdentityNames { get; set; }
        public virtual DbSet<IdentityIdentifier> IdentityIdentifiers { get; set; }
        public virtual DbSet<IdentityAttribute> IdentityAttributes { get; set; }
        public virtual DbSet<IdentityComment> IdentityComments { get; set; }
        public virtual DbSet<IdentityKnownAssociate> IdentityKnownAssociates { get; set; }
        public virtual DbSet<IdentityPhysicalDescription> IdentityPhysicalDescriptions { get; set; }
        public virtual DbSet<IdentityRelationship> IdentityRelationships { get; set; }
        public virtual DbSet<IdentityDerogatory> IdentityDerogatories { get; set; }
        public virtual DbSet<DerogatoryCategory> DerogatoryCategories { get; set; }
        public virtual DbSet<DerogatorySubCategory> DerogatorySubCategories { get; set; }
        public virtual DbSet<IdentityEncounter> IdentityEncounters { get; set; }
        public virtual DbSet<IdentityAttachment> IdentityAttachments { get; set; }
        public virtual DbSet<IdentitySocialMedia> IdentitySocialMedias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //USE THIS TO SELECT THE SCHEMA ON POSTGRES
            modelBuilder.HasDefaultSchema("BI2R");

        }
    }



}
 
