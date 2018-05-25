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
		public virtual DbSet<UserQualification> UserQualifications { get; set; }
		public virtual DbSet<UserLanguage> UserLanguages { get; set; }
		public virtual DbSet<UserSkill> UserSkills { get; set; }
		public virtual DbSet<UserWorkExperience> UserWorkExperiences { get; set; }
		public virtual DbSet<UserEmail> UserEmails { get; set; }
		public virtual DbSet<UserPhone> UserPhones { get; set; }
		public virtual DbSet<UserAddress> UserAddresses { get; set; }
		public virtual DbSet<UserSetting> UserSettings { get; set; }
		public virtual DbSet<UserName> UserNames { get; set; }
        public virtual DbSet<UserAttachment> UserAttachments { get; set; }
        public virtual DbSet<UserAttribute> UserAttributes { get; set; }
        public virtual DbSet<UserComment> UserComments { get; set; }
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
            //modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
            //modelBuilder.Entity<User>().Property(x => x.AppName).HasMaxLength(20).




        }
    }
}
 
