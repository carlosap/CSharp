﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using UserManager;

namespace UserManager.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20180523205000_0001_InitTables")]
    partial class _0001_InitTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserManager.AddressType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AddressTypes");
                });

            modelBuilder.Entity("UserManager.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("UserManager.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("UserManager.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("UserManager.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("MaritalStatuses");
                });

            modelBuilder.Entity("UserManager.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Menu2Id");

                    b.Property<string>("MenuText")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("MenuURL")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int?>("ParentId");

                    b.Property<int?>("SortOrder");

                    b.HasKey("Id");

                    b.HasIndex("Menu2Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("UserManager.MenuPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("IsCreate");

                    b.Property<bool?>("IsDelete");

                    b.Property<bool?>("IsRead");

                    b.Property<bool?>("IsUpdate");

                    b.Property<int?>("MenuId");

                    b.Property<int?>("RoleId")
                        .IsRequired();

                    b.Property<int?>("SortOrder");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("MenuPermissions");
                });

            modelBuilder.Entity("UserManager.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("UserManager.RoleUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RoleId")
                        .IsRequired();

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUsers");
                });

            modelBuilder.Entity("UserManager.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("UserManager.User", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<DateTime>("Dated");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("EmailSignature");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("GenderId")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("MaritalStatusId")
                        .IsRequired();

                    b.Property<string>("MiddleName")
                        .HasMaxLength(100);

                    b.Property<Guid?>("ParentId");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(15);

                    b.Property<string>("ProfilePicture");

                    b.Property<Guid?>("User2Id");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Website")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.HasIndex("User2Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserManager.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int?>("AddressTypeId")
                        .IsRequired();

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AddressTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("UserManager.UserAttachment", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<string>("ReferringDocument");

                    b.Property<string>("Type");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAttachments");
                });

            modelBuilder.Entity("UserManager.UserAttribute", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAttributes");
                });

            modelBuilder.Entity("UserManager.UserComment", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Format")
                        .HasMaxLength(20);

                    b.Property<string>("Type");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserComments");
                });

            modelBuilder.Entity("UserManager.UserDerogatory", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApprovalDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Justification");

                    b.Property<string>("NominationDate");

                    b.Property<string>("NominatorGroup");

                    b.Property<string>("Region")
                        .HasMaxLength(100);

                    b.Property<string>("Source");

                    b.Property<string>("Status")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserDerogatories");
                });

            modelBuilder.Entity("UserManager.UserEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserEmails");
                });

            modelBuilder.Entity("UserManager.UserEncounter", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EncounterDate");

                    b.Property<string>("Format")
                        .HasMaxLength(20);

                    b.Property<string>("Location");

                    b.Property<string>("Reason");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserEncounters");
                });

            modelBuilder.Entity("UserManager.UserGeoLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserGeoLocations");
                });

            modelBuilder.Entity("UserManager.UserKnownAssociate", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Address1")
                        .HasMaxLength(100);

                    b.Property<string>("BusinessPhone")
                        .HasMaxLength(15);

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("Company")
                        .HasMaxLength(50);

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FaxNumber")
                        .HasMaxLength(15);

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("HomePhone")
                        .HasMaxLength(15);

                    b.Property<string>("JobTitle")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(30);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("MobilePhone")
                        .HasMaxLength(15);

                    b.Property<string>("Notes");

                    b.Property<string>("Province")
                        .HasMaxLength(50);

                    b.Property<int?>("StateId");

                    b.Property<string>("Type")
                        .HasMaxLength(20);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.Property<string>("WebPage");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserKnownAssociates");
                });

            modelBuilder.Entity("UserManager.UserLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LanguageId")
                        .IsRequired();

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("UserManager.UserName", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullName")
                        .HasMaxLength(50);

                    b.Property<string>("GivenName")
                        .HasMaxLength(50);

                    b.Property<string>("Surname")
                        .HasMaxLength(50);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserNames");
                });

            modelBuilder.Entity("UserManager.UserNationality", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Citizenship")
                        .HasMaxLength(100);

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Ethnicity")
                        .HasMaxLength(100);

                    b.Property<string>("Nationality")
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserNationalities");
                });

            modelBuilder.Entity("UserManager.UserOrigin", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DoB");

                    b.Property<string>("Format")
                        .HasMaxLength(20);

                    b.Property<int?>("StateId");

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .HasMaxLength(10);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOrigins");
                });

            modelBuilder.Entity("UserManager.UserPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPhones");
                });

            modelBuilder.Entity("UserManager.UserPhysicalDescription", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(15);

                    b.Property<string>("Format")
                        .HasMaxLength(15);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserPhysicalDescriptions");
                });

            modelBuilder.Entity("UserManager.UserQualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BoardUniversity")
                        .HasMaxLength(50);

                    b.Property<string>("FromYear")
                        .HasMaxLength(10);

                    b.Property<string>("OutOfMarks")
                        .HasMaxLength(50);

                    b.Property<string>("Percentage")
                        .HasMaxLength(50);

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ToYear")
                        .HasMaxLength(10);

                    b.Property<string>("TotalMarks")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserQualifications");
                });

            modelBuilder.Entity("UserManager.UserRelationship", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Justification");

                    b.Property<string>("Name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRelationships");
                });

            modelBuilder.Entity("UserManager.UserSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SettingGroup")
                        .HasMaxLength(100);

                    b.Property<string>("SettingKey")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("SettingValue")
                        .IsRequired();

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("UserManager.UserSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("UserManager.UserSocialMedia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About")
                        .HasMaxLength(200);

                    b.Property<string>("ProfileImage")
                        .HasMaxLength(50);

                    b.Property<string>("ProfileUrl")
                        .HasMaxLength(50);

                    b.Property<string>("SocialMediaName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSocialMedias");
                });

            modelBuilder.Entity("UserManager.UserWorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("From");

                    b.Property<string>("JobDescription");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("To");

                    b.Property<Guid?>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserWorkExperiences");
                });

            modelBuilder.Entity("UserManager.Menu", b =>
                {
                    b.HasOne("UserManager.Menu", "Menu2")
                        .WithMany("Menu_ParentIds")
                        .HasForeignKey("Menu2Id");
                });

            modelBuilder.Entity("UserManager.MenuPermission", b =>
                {
                    b.HasOne("UserManager.Menu", "Menu_MenuId")
                        .WithMany("MenuPermission_MenuIds")
                        .HasForeignKey("MenuId");

                    b.HasOne("UserManager.Role", "Role_RoleId")
                        .WithMany("MenuPermission_RoleIds")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("MenuPermission_UserIds")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("UserManager.RoleUser", b =>
                {
                    b.HasOne("UserManager.Role", "Role_RoleId")
                        .WithMany("RoleUser_RoleIds")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("RoleUser_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.State", b =>
                {
                    b.HasOne("UserManager.Country")
                        .WithMany("State_CountryIds")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("UserManager.User", b =>
                {
                    b.HasOne("UserManager.Gender", "Gender_GenderId")
                        .WithMany("User_GenderIds")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManager.MaritalStatus", "MaritalStatus_MaritalStatusId")
                        .WithMany("User_MaritalStatusIds")
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManager.User", "User2")
                        .WithMany("User_ParentIds")
                        .HasForeignKey("User2Id");
                });

            modelBuilder.Entity("UserManager.UserAddress", b =>
                {
                    b.HasOne("UserManager.AddressType", "AddressType_AddressTypeId")
                        .WithMany("UserAddress_AddressTypeIds")
                        .HasForeignKey("AddressTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserAddress_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserAttachment", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserAttribute", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserComment", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserDerogatory", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserEmail", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserEmail_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserEncounter", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserGeoLocation", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserGeopLocation_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserKnownAssociate", b =>
                {
                    b.HasOne("UserManager.Country", "Country_CountryId")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("UserManager.State", "State_StateId")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserLanguage", b =>
                {
                    b.HasOne("UserManager.Language", "Language_LanguageId")
                        .WithMany("UserLanguage_LanguageIds")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserLanguage_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserName", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserNationality", b =>
                {
                    b.HasOne("UserManager.Country", "Country_CountryId")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserOrigin", b =>
                {
                    b.HasOne("UserManager.Country", "Country_CountryId")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("UserManager.State", "State_StateId")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserPhone", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserPhone_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserPhysicalDescription", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserQualification", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserQualification_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserRelationship", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserSetting", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserSetting_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserSkill", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserSkill_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserSocialMedia", b =>
                {
                    b.HasOne("UserManager.User", "User_IdentityId")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UserManager.UserWorkExperience", b =>
                {
                    b.HasOne("UserManager.User", "User_UserId")
                        .WithMany("UserWorkExperience_UserIds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
