using Microsoft.EntityFrameworkCore;
namespace UserManager
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options){}
        public UserContext() { }

        public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<RoleUser> RoleUsers { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
		public virtual DbSet<Gender> Genders { get; set; }
		public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
		public virtual DbSet<UserQualification> UserQualifications { get; set; }
		public virtual DbSet<UserLanguage> UserLanguages { get; set; }
		public virtual DbSet<UserSkill> UserSkills { get; set; }
		public virtual DbSet<UserWorkExperience> UserWorkExperiences { get; set; }
		public virtual DbSet<UserEmail> UserEmails { get; set; }
		public virtual DbSet<UserPhone> UserPhones { get; set; }
		public virtual DbSet<UserAddress> UserAddresses { get; set; }
		public virtual DbSet<Language> Languages { get; set; }
		public virtual DbSet<AddressType> AddressTypes { get; set; }
		public virtual DbSet<UserSetting> UserSettings { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<State> States { get; set; }
		public virtual DbSet<UserName> UserNames { get; set; }
        public virtual DbSet<UserAttachment> UserAttachments { get; set; }
        public virtual DbSet<UserAttribute> UserAttributes { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }
        public virtual DbSet<UserDerogatory> UserDerogatories { get; set; }
        public virtual DbSet<UserEncounter> UserEncounters { get; set; }
        public virtual DbSet<UserGeoLocation> UserGeoLocations { get; set; }
        public virtual DbSet<UserKnownAssociate> UserKnownAssociates { get; set; }
        public virtual DbSet<UserNationality> UserNationalities { get; set; }
        public virtual DbSet<UserOrigin> UserOrigins { get; set; }
        public virtual DbSet<UserPhysicalDescription> UserPhysicalDescriptions { get; set; }
        public virtual DbSet<UserRelationship> UserRelationships { get; set; }
        public virtual DbSet<UserSocialMedia> UserSocialMedias { get; set; }


        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////User Default Values
            //modelBuilder.Entity<User>().Property(x => x.UserId).HasDefaultValueSql("newsequentialid()");
            //modelBuilder.Entity<User>().Property(x => x.DateCreated).HasDefaultValueSql("GetUtcDate()");
            //modelBuilder.Entity<User>().Property(x => x.LastUpdate).HasDefaultValueSql("GetUtcDate()");
            //modelBuilder.Entity<User>().Property(x => x.ReportsTo).HasDefaultValueSql("null");
            //modelBuilder.Entity<User>().Property(x => x.EmailConfirmed).HasDefaultValueSql("0");
            //modelBuilder.Entity<User>().Property(x => x.EmailNotification).HasDefaultValueSql("0");
            //modelBuilder.Entity<User>().Property(x => x.PhoneNotification).HasDefaultValueSql("0");
            //modelBuilder.Entity<User>().Property(x => x.PhoneConfirmed).HasDefaultValueSql("0");
            //modelBuilder.Entity<User>().Property(x => x.LockEnabled).HasDefaultValueSql("0");
            //modelBuilder.Entity<User>().Property(x => x.AccessFailedCount).HasDefaultValue(0);
            ////User Max Lengths
            //modelBuilder.Entity<User>().Property(x => x.FirstName).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.LastName).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.Company).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.JobTitle).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.FaxPhone).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.MobilePhone).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.Address1).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.Address2).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.ApartmentNumber).HasMaxLength(10);
            //modelBuilder.Entity<User>().Property(x => x.CityOrProvince).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.ZipOrPostalCode).HasMaxLength(30);
            //modelBuilder.Entity<User>().Property(x => x.PhoneNumber).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.LockoutDescription).HasMaxLength(100);
            //modelBuilder.Entity<User>().Property(x => x.AppName).HasMaxLength(20);
        }
        //
    }
}
 
