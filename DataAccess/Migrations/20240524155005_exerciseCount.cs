using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class exerciseCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ca1abc7-24b8-4d66-a7b1-b21adc12101c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85ca37a2-5824-4c56-afff-ad6ccce81162", "AQAAAAIAAYagAAAAELuMcITmkaXSHiJkF1h8B+G6svvb9mJtYwwY3Hmq6rXd46+i70RRXmaXSnGFbSVb/A==", "d63c3ce1-96a9-40d0-bef9-275017675cf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d8b0a60-e3b1-4088-9ff5-6b0a68d80cac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "206f134c-69c4-4a3a-8c5b-e75553ed41fd", "AQAAAAIAAYagAAAAEIQhi0IYVu6VGzLWHCIPpKbYK/y2UgJJs755saY0pQW4LuBkJf/aEjWnbfy+tAVzlw==", "be3a7222-eae0-4e7f-bb33-a6d1b096db4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f47c5bf1-740c-4fb9-94b7-941e90ad7d23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6b94bcb-7c41-4cc6-b4d7-8c4465f22d3b", "AQAAAAIAAYagAAAAEA8TFO9N9xizXfkU4bPHa1L9kcJiAEf9mkKjUAJJ2JwPCrbSz3Dz5cQZtwhOCifelA==", "d7c50d99-1aee-4b9b-a74c-f6be3ca93569" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1ca1abc7-24b8-4d66-a7b1-b21adc12101c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62342e0b-85c4-43a7-8786-d3427bca52b8", "AQAAAAIAAYagAAAAECzZqrkgiPz6Qk3tqqXvxqQoCCilFOXxirCokIl1nEXrNfzHUBE63hhNrxf4PCbzfg==", "12de31a5-0628-4b69-b290-eb7525f73733" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d8b0a60-e3b1-4088-9ff5-6b0a68d80cac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10eb8cfc-8a92-44a6-bd11-6fa440a8d203", "AQAAAAIAAYagAAAAEEOSZOiqMGGbKwPELYBUgcFXSOXtGQKnYI/k8mPyBS565U+pe9JIwTn9cWxb23urbA==", "f5d2109e-07a1-4c39-aaa1-0b0fba42f017" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f47c5bf1-740c-4fb9-94b7-941e90ad7d23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25e8801f-2c1d-4d21-8177-e9589ce6b2df", "AQAAAAIAAYagAAAAEO1y8ayMxtbsV7VwX96be5m7HgfvKwXcQnZ+v+o42/8clk8DvOK9mHDZWl42tJ5g0w==", "c2ee8ccc-726a-4f78-9e19-ccf2e6740c26" });
        }
    }
}
