using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UserManager.Migrations
{
    public partial class _0001_InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Menu2Id = table.Column<int>(nullable: true),
                    MenuText = table.Column<string>(maxLength: 100, nullable: false),
                    MenuURL = table.Column<string>(maxLength: 400, nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    SortOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_Menu2Id",
                        column: x => x.Menu2Id,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Dated = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    EmailSignature = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    User2Id = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Website = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCreate = table.Column<bool>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: true),
                    IsRead = table.Column<bool>(nullable: true),
                    IsUpdate = table.Column<bool>(nullable: true),
                    MenuId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ReferringDocument = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAttachments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAttributes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Format = table.Column<string>(maxLength: 20, nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDerogatories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApprovalDate = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Justification = table.Column<string>(nullable: true),
                    NominationDate = table.Column<string>(nullable: true),
                    NominatorGroup = table.Column<string>(nullable: true),
                    Region = table.Column<string>(maxLength: 100, nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDerogatories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDerogatories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEmails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEncounters",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    EncounterDate = table.Column<DateTime>(nullable: false),
                    Format = table.Column<string>(maxLength: 20, nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEncounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEncounters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGeoLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<string>(maxLength: 50, nullable: false),
                    Longitude = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGeoLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGeoLocations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserKnownAssociates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Address1 = table.Column<string>(maxLength: 100, nullable: true),
                    BusinessPhone = table.Column<string>(maxLength: 15, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Company = table.Column<string>(maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    FaxNumber = table.Column<string>(maxLength: 15, nullable: true),
                    FirstName = table.Column<string>(maxLength: 30, nullable: true),
                    HomePhone = table.Column<string>(maxLength: 15, nullable: true),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 30, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 15, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Province = table.Column<string>(maxLength: 50, nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(maxLength: 20, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    WebPage = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKnownAssociates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserKnownAssociates_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserKnownAssociates_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserKnownAssociates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    GivenName = table.Column<string>(maxLength: 50, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNationalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Citizenship = table.Column<string>(maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Ethnicity = table.Column<string>(maxLength: 100, nullable: true),
                    Nationality = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNationalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNationalities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNationalities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrigins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DoB = table.Column<DateTime>(nullable: true),
                    Format = table.Column<string>(maxLength: 20, nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrigins_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrigins_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrigins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPhysicalDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 15, nullable: true),
                    Format = table.Column<string>(maxLength: 15, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhysicalDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhysicalDescriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardUniversity = table.Column<string>(maxLength: 50, nullable: true),
                    FromYear = table.Column<string>(maxLength: 10, nullable: true),
                    OutOfMarks = table.Column<string>(maxLength: 50, nullable: true),
                    Percentage = table.Column<string>(maxLength: 50, nullable: true),
                    Qualification = table.Column<string>(maxLength: 100, nullable: false),
                    ToYear = table.Column<string>(maxLength: 10, nullable: true),
                    TotalMarks = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQualifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRelationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Justification = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRelationships_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SettingGroup = table.Column<string>(maxLength: 100, nullable: true),
                    SettingKey = table.Column<string>(maxLength: 100, nullable: false),
                    SettingValue = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialMedias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    About = table.Column<string>(maxLength: 200, nullable: true),
                    ProfileImage = table.Column<string>(maxLength: 50, nullable: true),
                    ProfileUrl = table.Column<string>(maxLength: 50, nullable: true),
                    SocialMediaName = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSocialMedias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    From = table.Column<DateTime>(nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(maxLength: 100, nullable: false),
                    To = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWorkExperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_MenuId",
                table: "MenuPermissions",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_RoleId",
                table: "MenuPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermissions_UserId",
                table: "MenuPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_Menu2Id",
                table: "Menus",
                column: "Menu2Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_RoleId",
                table: "RoleUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_UserId",
                table: "RoleUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AddressTypeId",
                table: "UserAddresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAttachments_UserId",
                table: "UserAttachments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAttributes_UserId",
                table: "UserAttributes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserId",
                table: "UserComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDerogatories_UserId",
                table: "UserDerogatories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEmails_UserId",
                table: "UserEmails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEncounters_UserId",
                table: "UserEncounters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGeoLocations_UserId",
                table: "UserGeoLocations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKnownAssociates_CountryId",
                table: "UserKnownAssociates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKnownAssociates_StateId",
                table: "UserKnownAssociates",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKnownAssociates_UserId",
                table: "UserKnownAssociates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_LanguageId",
                table: "UserLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_UserId",
                table: "UserLanguages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNames_UserId",
                table: "UserNames",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNationalities_CountryId",
                table: "UserNationalities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNationalities_UserId",
                table: "UserNationalities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrigins_CountryId",
                table: "UserOrigins",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrigins_StateId",
                table: "UserOrigins",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrigins_UserId",
                table: "UserOrigins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhones_UserId",
                table: "UserPhones",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhysicalDescriptions_UserId",
                table: "UserPhysicalDescriptions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQualifications_UserId",
                table: "UserQualifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationships_UserId",
                table: "UserRelationships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MaritalStatusId",
                table: "Users",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_User2Id",
                table: "Users",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkills_UserId",
                table: "UserSkills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialMedias_UserId",
                table: "UserSocialMedias",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkExperiences_UserId",
                table: "UserWorkExperiences",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuPermissions");

            migrationBuilder.DropTable(
                name: "RoleUsers");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserAttachments");

            migrationBuilder.DropTable(
                name: "UserAttributes");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "UserDerogatories");

            migrationBuilder.DropTable(
                name: "UserEmails");

            migrationBuilder.DropTable(
                name: "UserEncounters");

            migrationBuilder.DropTable(
                name: "UserGeoLocations");

            migrationBuilder.DropTable(
                name: "UserKnownAssociates");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "UserNames");

            migrationBuilder.DropTable(
                name: "UserNationalities");

            migrationBuilder.DropTable(
                name: "UserOrigins");

            migrationBuilder.DropTable(
                name: "UserPhones");

            migrationBuilder.DropTable(
                name: "UserPhysicalDescriptions");

            migrationBuilder.DropTable(
                name: "UserQualifications");

            migrationBuilder.DropTable(
                name: "UserRelationships");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "UserSkills");

            migrationBuilder.DropTable(
                name: "UserSocialMedias");

            migrationBuilder.DropTable(
                name: "UserWorkExperiences");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");
        }
    }
}
