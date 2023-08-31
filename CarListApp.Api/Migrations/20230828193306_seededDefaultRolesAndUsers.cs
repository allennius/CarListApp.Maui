using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarListApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class seededDefaultRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33b160d2-341e-4799-af9d-6bd149226c62", null, "User", "USER" },
                    { "5b827e64-4126-490a-8834-fb9a7c47f6b3", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6490751e-1342-476a-bb01-a515eadafa78", 0, "64d096a4-b8f4-4739-a29a-e36346ada6f6", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEI+m85bjBM+R3f28QCs0RS9V0HtBfiVsrYq14kIuBMnLrWJ+AAN4HrYrNoFjlEL92Q==", null, false, "eb02f908-c159-4778-a969-ba5d711f0723", false, "admin@localhost.com" },
                    { "d9496331-4421-4d51-9c19-3f3e67c93913", 0, "061950dd-69d4-49f2-b202-eb825624547e", "user@localhost.com", true, false, null, "USER@LOCALHOST.COM", "USER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOpi7qzs1HA4W3y1x9Jyz41VaCkC2uU90IJPZzM0EN7KGHOE7oN3wCWlLlilmnB35A==", null, false, "c8c7fa44-9ee0-41e7-85b0-c954be7ad822", false, "user@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5b827e64-4126-490a-8834-fb9a7c47f6b3", "6490751e-1342-476a-bb01-a515eadafa78" },
                    { "33b160d2-341e-4799-af9d-6bd149226c62", "d9496331-4421-4d51-9c19-3f3e67c93913" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b827e64-4126-490a-8834-fb9a7c47f6b3", "6490751e-1342-476a-bb01-a515eadafa78" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "33b160d2-341e-4799-af9d-6bd149226c62", "d9496331-4421-4d51-9c19-3f3e67c93913" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33b160d2-341e-4799-af9d-6bd149226c62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b827e64-4126-490a-8834-fb9a7c47f6b3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6490751e-1342-476a-bb01-a515eadafa78");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9496331-4421-4d51-9c19-3f3e67c93913");
        }
    }
}
