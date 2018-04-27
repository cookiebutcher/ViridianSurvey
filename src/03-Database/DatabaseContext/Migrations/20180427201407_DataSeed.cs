using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViridianCode.ViridianSurvey.DatabaseContext.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "IsActive", "LastName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { 1, new DateTime(2018, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "janusz@testow.com", "Janusz", true, "Testów", null, null, "admin" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "AllowBackwardNavigation", "Code", "CreatedById", "CreatedDate", "Description", "EndMessage", "ShowGroupDescription", "ShowGroupName", "ShowProgressBar", "ShowWelcomeScreen", "Title", "WelcomeMessage" },
                values: new object[] { 1, false, "S001", 1, new DateTime(2018, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "descriptionik", "end mesedzyk", false, false, false, false, "titelek", "welcome mesedzyk" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
