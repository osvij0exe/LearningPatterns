using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Consultorio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Authentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("3c333613-cd70-4803-8e82-402595e0151c"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("5f511477-9635-4c74-a0c8-966cb664e3aa"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("a21307c2-9901-4afd-adeb-2bdff72ce139"));

            migrationBuilder.InsertData(
                table: "ConsultorioEntity",
                columns: new[] { "Id", "Active", "CreationDate", "MedicalOficceNumber", "Speciality", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("39017484-9b5a-406b-a8cd-f62d9a60b46e"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cardiology", null },
                    { new Guid("500e8c7a-5b2c-4dd7-9728-e9cc9f4d4eb7"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Neumology", null },
                    { new Guid("b9002d5c-415c-419c-a9da-0ac6f6b88243"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pediatric Cardiology", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("39017484-9b5a-406b-a8cd-f62d9a60b46e"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("500e8c7a-5b2c-4dd7-9728-e9cc9f4d4eb7"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("b9002d5c-415c-419c-a9da-0ac6f6b88243"));

            migrationBuilder.InsertData(
                table: "ConsultorioEntity",
                columns: new[] { "Id", "Active", "CreationDate", "MedicalOficceNumber", "Speciality", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3c333613-cd70-4803-8e82-402595e0151c"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cardiology", null },
                    { new Guid("5f511477-9635-4c74-a0c8-966cb664e3aa"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Neumology", null },
                    { new Guid("a21307c2-9901-4afd-adeb-2bdff72ce139"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pediatric Cardiology", null }
                });
        }
    }
}
