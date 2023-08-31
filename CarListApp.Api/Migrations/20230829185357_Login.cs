using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarListApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class Login : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6490751e-1342-476a-bb01-a515eadafa78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ccd81a2-1110-424a-b285-8b7dcb532a37", "AQAAAAIAAYagAAAAELTFl4/qkax+SAsHPCrkG+ipmiEkXgcM/RngR4YaIN27cVc0TLVCvHpgCpfxgQQL8Q==", "50cc4d68-7d7a-4df7-a158-d80fbf6a2081" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9496331-4421-4d51-9c19-3f3e67c93913",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd39b405-6ea7-4bf3-9491-95d3544c78f0", "AQAAAAIAAYagAAAAEJgKkB0bTz3T885m5W95inllfZmJVQBqdmqt3Y3DmEz4cHuzIzhI3AZ0S+pOPBC5yQ==", "678aa3d6-327e-4a35-a7e8-979d00ed3624" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6490751e-1342-476a-bb01-a515eadafa78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64d096a4-b8f4-4739-a29a-e36346ada6f6", "AQAAAAIAAYagAAAAEI+m85bjBM+R3f28QCs0RS9V0HtBfiVsrYq14kIuBMnLrWJ+AAN4HrYrNoFjlEL92Q==", "eb02f908-c159-4778-a969-ba5d711f0723" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9496331-4421-4d51-9c19-3f3e67c93913",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "061950dd-69d4-49f2-b202-eb825624547e", "AQAAAAIAAYagAAAAEOpi7qzs1HA4W3y1x9Jyz41VaCkC2uU90IJPZzM0EN7KGHOE7oN3wCWlLlilmnB35A==", "c8c7fa44-9ee0-41e7-85b0-c954be7ad822" });
        }
    }
}
