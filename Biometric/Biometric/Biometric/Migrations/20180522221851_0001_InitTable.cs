using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Biometric.Migrations
{
    public partial class _0001_InitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BI2R");

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "BI2R",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Identities",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ATPScore = table.Column<int>(nullable: false),
                    About = table.Column<string>(nullable: true),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    Identity2Id = table.Column<Guid>(nullable: true),
                    IdentityName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    MaritalStatusId = table.Column<int>(nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    URI = table.Column<string>(nullable: true),
                    USPerson = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Identities_Genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "BI2R",
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Identities_Identities_Identity2Id",
                        column: x => x.Identity2Id,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Identities_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalSchema: "BI2R",
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityAddresss",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address = table.Column<string>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false),
                    IdentityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityAddresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityAddresss_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalSchema: "BI2R",
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityAddresss_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityAttachments",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    Path = table.Column<string>(nullable: true),
                    ReferringDocument = table.Column<string>(nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityAttachments_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityAttributes",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityAttributes_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityComments",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    Format = table.Column<string>(maxLength: 20, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityComments_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityDerogatories",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApprovalDate = table.Column<string>(nullable: true),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Justification = table.Column<string>(nullable: true),
                    NominationDate = table.Column<string>(nullable: true),
                    NominatorGroup = table.Column<string>(nullable: true),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    Region = table.Column<string>(maxLength: 100, nullable: true),
                    Source = table.Column<string>(nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityDerogatories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityDerogatories_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityEmails",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    EmailSignature = table.Column<string>(nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityEmails_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityEncounters",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    EncounterDate = table.Column<DateTime>(nullable: false),
                    Format = table.Column<string>(maxLength: 20, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityEncounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityEncounters_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityGeoLocations",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Latitude = table.Column<string>(maxLength: 50, nullable: false),
                    Longitude = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityGeoLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityGeoLocations_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityIdentifiers",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityIdentifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityIdentifiers_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityKnownAssociates",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Bid = table.Column<string>(nullable: true),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityKnownAssociates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityKnownAssociates_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityLanguages",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdentityId = table.Column<Guid>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityLanguages_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "BI2R",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityNames",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    GivenName = table.Column<string>(maxLength: 50, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    Surname = table.Column<string>(maxLength: 50, nullable: true),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityNames_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityNationalities",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Citizenship = table.Column<string>(maxLength: 100, nullable: true),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    Ethnicity = table.Column<string>(maxLength: 100, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Nationality = table.Column<string>(maxLength: 100, nullable: true),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityNationalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityNationalities_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityOrigins",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    Format = table.Column<string>(maxLength: 20, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    State = table.Column<string>(maxLength: 50, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityOrigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityOrigins_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityPhones",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdentityId = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityPhones_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityPhysicalDescriptions",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    Format = table.Column<string>(nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityPhysicalDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityPhysicalDescriptions_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityQualifications",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BoardUniversity = table.Column<string>(maxLength: 50, nullable: true),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    FromYear = table.Column<string>(maxLength: 10, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    OutOfMarks = table.Column<string>(maxLength: 50, nullable: true),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    Percentage = table.Column<string>(maxLength: 50, nullable: true),
                    Qualification = table.Column<string>(maxLength: 100, nullable: false),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    ToYear = table.Column<string>(maxLength: 10, nullable: true),
                    TotalMarks = table.Column<string>(maxLength: 50, nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityQualifications_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRelationships",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Justification = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRelationships_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentitySkills",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SkillName = table.Column<string>(maxLength: 100, nullable: false),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentitySkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentitySkills_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentitySocialMedias",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    About = table.Column<string>(maxLength: 200, nullable: true),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    ProfileImage = table.Column<string>(maxLength: 50, nullable: true),
                    ProfileUrl = table.Column<string>(maxLength: 50, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentitySocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentitySocialMedias_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityWorkExperiences",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    From = table.Column<DateTime>(nullable: true),
                    IdentityId = table.Column<Guid>(nullable: false),
                    JobDescription = table.Column<string>(nullable: true),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    RoleName = table.Column<string>(maxLength: 100, nullable: false),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    To = table.Column<DateTime>(nullable: true),
                    UserID = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityWorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityWorkExperiences_Identities_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "BI2R",
                        principalTable: "Identities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DerogatoryCategories",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityDerogatoryId = table.Column<Guid>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    UserID = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DerogatoryCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DerogatoryCategories_IdentityDerogatories_IdentityDerogatoryId",
                        column: x => x.IdentityDerogatoryId,
                        principalSchema: "BI2R",
                        principalTable: "IdentityDerogatories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DerogatorySubCategories",
                schema: "BI2R",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClassificationString = table.Column<string>(maxLength: 30, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    Dissem = table.Column<string>(maxLength: 30, nullable: true),
                    IdentityDerogatoryId = table.Column<Guid>(nullable: false),
                    OwnerProducer = table.Column<string>(maxLength: 30, nullable: true),
                    SrcConfidence = table.Column<string>(maxLength: 100, nullable: true),
                    SrcIdpk = table.Column<string>(nullable: true),
                    SrcName = table.Column<string>(maxLength: 30, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DerogatorySubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DerogatorySubCategories_IdentityDerogatories_IdentityDerogatoryId",
                        column: x => x.IdentityDerogatoryId,
                        principalSchema: "BI2R",
                        principalTable: "IdentityDerogatories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DerogatoryCategories_IdentityDerogatoryId",
                schema: "BI2R",
                table: "DerogatoryCategories",
                column: "IdentityDerogatoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DerogatorySubCategories_IdentityDerogatoryId",
                schema: "BI2R",
                table: "DerogatorySubCategories",
                column: "IdentityDerogatoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Identities_GenderId",
                schema: "BI2R",
                table: "Identities",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Identities_Identity2Id",
                schema: "BI2R",
                table: "Identities",
                column: "Identity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Identities_MaritalStatusId",
                schema: "BI2R",
                table: "Identities",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityAddresss_AddressTypeId",
                schema: "BI2R",
                table: "IdentityAddresss",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityAddresss_IdentityId",
                schema: "BI2R",
                table: "IdentityAddresss",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityAttachments_IdentityId",
                schema: "BI2R",
                table: "IdentityAttachments",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityAttributes_IdentityId",
                schema: "BI2R",
                table: "IdentityAttributes",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityComments_IdentityId",
                schema: "BI2R",
                table: "IdentityComments",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityDerogatories_IdentityId",
                schema: "BI2R",
                table: "IdentityDerogatories",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityEmails_IdentityId",
                schema: "BI2R",
                table: "IdentityEmails",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityEncounters_IdentityId",
                schema: "BI2R",
                table: "IdentityEncounters",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityGeoLocations_IdentityId",
                schema: "BI2R",
                table: "IdentityGeoLocations",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityIdentifiers_IdentityId",
                schema: "BI2R",
                table: "IdentityIdentifiers",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityKnownAssociates_IdentityId",
                schema: "BI2R",
                table: "IdentityKnownAssociates",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityLanguages_IdentityId",
                schema: "BI2R",
                table: "IdentityLanguages",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityLanguages_LanguageId",
                schema: "BI2R",
                table: "IdentityLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityNames_IdentityId",
                schema: "BI2R",
                table: "IdentityNames",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityNationalities_IdentityId",
                schema: "BI2R",
                table: "IdentityNationalities",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityOrigins_IdentityId",
                schema: "BI2R",
                table: "IdentityOrigins",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityPhones_IdentityId",
                schema: "BI2R",
                table: "IdentityPhones",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityPhysicalDescriptions_IdentityId",
                schema: "BI2R",
                table: "IdentityPhysicalDescriptions",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityQualifications_IdentityId",
                schema: "BI2R",
                table: "IdentityQualifications",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRelationships_IdentityId",
                schema: "BI2R",
                table: "IdentityRelationships",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentitySkills_IdentityId",
                schema: "BI2R",
                table: "IdentitySkills",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentitySocialMedias_IdentityId",
                schema: "BI2R",
                table: "IdentitySocialMedias",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityWorkExperiences_IdentityId",
                schema: "BI2R",
                table: "IdentityWorkExperiences",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                schema: "BI2R",
                table: "States",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DerogatoryCategories",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "DerogatorySubCategories",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityAddresss",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityAttachments",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityAttributes",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityComments",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityEmails",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityEncounters",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityGeoLocations",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityIdentifiers",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityKnownAssociates",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityLanguages",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityNames",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityNationalities",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityOrigins",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityPhones",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityPhysicalDescriptions",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityQualifications",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityRelationships",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentitySkills",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentitySocialMedias",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityWorkExperiences",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "States",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "IdentityDerogatories",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "AddressTypes",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "Identities",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "BI2R");

            migrationBuilder.DropTable(
                name: "MaritalStatuses",
                schema: "BI2R");
        }
    }
}
