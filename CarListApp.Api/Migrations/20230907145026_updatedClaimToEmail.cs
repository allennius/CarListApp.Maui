using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarListApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class updatedClaimToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6490751e-1342-476a-bb01-a515eadafa78",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "888f3aac-e9c5-40b0-9ac1-5d168b0ba0b4", "AQAAAAIAAYagAAAAEHuJx8L7/WULYcENc0nVcGG1oO0eWw74SmKbscU4fyDUFz7KHZSgFs98pVe1n6GqWw==", "fdbadf42-2f51-4ca0-8532-958000a743b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9496331-4421-4d51-9c19-3f3e67c93913",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3983743a-81cd-4aea-997d-83f003829dd9", "AQAAAAIAAYagAAAAEGvcIV+naTtD8rk/14NtRG3g2AVPFlSsiQz+OgtLDhD9h7N0P05gx9vXL2vELPnw/A==", "3c1ffdd9-e4de-49cf-bbad-702f40556801" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
