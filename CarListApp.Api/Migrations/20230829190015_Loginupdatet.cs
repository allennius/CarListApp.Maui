using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarListApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class Loginupdatet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6490751e-1342-476a-bb01-a515eadafa78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbb1d927-f6a7-4345-8caf-17b1517ba370", "AQAAAAIAAYagAAAAECgtbPuR9L2Ia+4eHPAMG4QY/mWL0O4Ut4yJTDlzN3RLVpWlAVg/nkvoG/kxAxcBjw==", "ae0c833f-dcc2-41fc-abc1-67e9ad3d0fcc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9496331-4421-4d51-9c19-3f3e67c93913",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b5b9c37-ec6c-47c5-acb5-4151b2371b74", "AQAAAAIAAYagAAAAEPtRs0WK9HT2vuIEEvTqMFiETbFjU8JMS71kNow+DAR3Q6OQ6L1jl4YV6/mtsGCYYQ==", "342df51d-6774-46c6-a0f1-89bf87f79af7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
