using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace UserManager.Migrations
{
    public partial class _0003_InitTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MaritalStatuses_MaritalStatusId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_User2Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserAttachments");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Users",
                newName: "Address1");

            migrationBuilder.RenameColumn(
                name: "User2Id",
                table: "Users",
                newName: "ReportsToId");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "Users",
                newName: "WebPage");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "MobilePhone");

            migrationBuilder.RenameColumn(
                name: "EmailSignature",
                table: "Users",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "Dated",
                table: "Users",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "DoB");

            migrationBuilder.RenameIndex(
                name: "IX_Users_User2Id",
                table: "Users",
                newName: "IX_Users_ReportsToId");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserRelationships",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserRelationships",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserPhysicalDescriptions",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserOrigins",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserOrigins",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserNationalities",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserNationalities",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserKnownAssociates",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserEncounters",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserEncounters",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserDerogatories",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserDerogatories",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserComments",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserComments",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserAttributes",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "UserAttributes",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "UserAttachments",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UserAttachments",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserAttachments",
                newName: "FileName");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "UserWorkExperiences",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "JobDescription",
                table: "UserWorkExperiences",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserWorkExperiences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserWorkExperiences",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserSocialMedias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserSocialMedias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserSkills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserSkills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserSettings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserSettings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Users",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatusId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppName",
                table: "Users",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarProfile",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone",
                table: "Users",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Users",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FaxNumber",
                table: "Users",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone",
                table: "Users",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Users",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockEnabled",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LockoutDescription",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Users",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Users",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Users",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserQualifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserQualifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserPhones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserPhones",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "UserPhones",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UserPhones",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserNames",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserNames",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserLanguages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserLanguages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "UserKnownAssociates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarProfile",
                table: "UserKnownAssociates",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DoB",
                table: "UserKnownAssociates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "UserKnownAssociates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusId",
                table: "UserKnownAssociates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "UserKnownAssociates",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserGeoLocations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserGeoLocations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserEmails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmailSignature",
                table: "UserEmails",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "UserEmails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Provider",
                table: "UserEmails",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileData",
                table: "UserAttachments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StateId",
                table: "Users",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKnownAssociates_GenderId",
                table: "UserKnownAssociates",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKnownAssociates_MaritalStatusId",
                table: "UserKnownAssociates",
                column: "MaritalStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserKnownAssociates_Genders_GenderId",
                table: "UserKnownAssociates",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKnownAssociates_MaritalStatuses_MaritalStatusId",
                table: "UserKnownAssociates",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MaritalStatuses_MaritalStatusId",
                table: "Users",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ReportsToId",
                table: "Users",
                column: "ReportsToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_States_StateId",
                table: "Users",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserKnownAssociates_Genders_GenderId",
                table: "UserKnownAssociates");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKnownAssociates_MaritalStatuses_MaritalStatusId",
                table: "UserKnownAssociates");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_MaritalStatuses_MaritalStatusId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ReportsToId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_States_StateId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CountryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StateId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserKnownAssociates_GenderId",
                table: "UserKnownAssociates");

            migrationBuilder.DropIndex(
                name: "IX_UserKnownAssociates_MaritalStatusId",
                table: "UserKnownAssociates");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserWorkExperiences");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserWorkExperiences");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserSocialMedias");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserSocialMedias");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserSkills");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserSkills");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AppName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AvatarProfile",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessPhone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FaxNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HomePhone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutDescription",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserQualifications");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserQualifications");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserPhones");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserPhones");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "UserPhones");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "UserPhones");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserNames");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserNames");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserLanguages");

            migrationBuilder.DropColumn(
                name: "About",
                table: "UserKnownAssociates");

            migrationBuilder.DropColumn(
                name: "AvatarProfile",
                table: "UserKnownAssociates");

            migrationBuilder.DropColumn(
                name: "DoB",
                table: "UserKnownAssociates");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "UserKnownAssociates");

            migrationBuilder.DropColumn(
                name: "MaritalStatusId",
                table: "UserKnownAssociates");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "UserKnownAssociates");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserGeoLocations");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserGeoLocations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserEmails");

            migrationBuilder.DropColumn(
                name: "EmailSignature",
                table: "UserEmails");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "UserEmails");

            migrationBuilder.DropColumn(
                name: "Provider",
                table: "UserEmails");

            migrationBuilder.DropColumn(
                name: "FileData",
                table: "UserAttachments");

            migrationBuilder.RenameColumn(
                name: "WebPage",
                table: "Users",
                newName: "ProfilePicture");

            migrationBuilder.RenameColumn(
                name: "ReportsToId",
                table: "Users",
                newName: "User2Id");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Users",
                newName: "EmailSignature");

            migrationBuilder.RenameColumn(
                name: "MobilePhone",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Users",
                newName: "Dated");

            migrationBuilder.RenameColumn(
                name: "DoB",
                table: "Users",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "Address1",
                table: "Users",
                newName: "Website");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ReportsToId",
                table: "Users",
                newName: "IX_Users_User2Id");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "UserRelationships",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserRelationships",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserPhysicalDescriptions",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "UserOrigins",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserOrigins",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "UserNationalities",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserNationalities",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserKnownAssociates",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "UserEncounters",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserEncounters",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "UserDerogatories",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserDerogatories",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "UserComments",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserComments",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "UserAttributes",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserAttributes",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "UserAttachments",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "UserAttachments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "UserAttachments",
                newName: "UpdatedDate");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "UserWorkExperiences",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobDescription",
                table: "UserWorkExperiences",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Users",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatusId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserAttachments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderId",
                table: "Users",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MaritalStatuses_MaritalStatusId",
                table: "Users",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_User2Id",
                table: "Users",
                column: "User2Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
