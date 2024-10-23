using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Consultorio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ConsultafixindTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("3138c493-ecf2-4831-82a9-192914ee872a"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("3402cef6-7ff7-4839-a2ef-b0d99da538ca"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("6b959f19-9057-40a8-a35b-4913c265b8f5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndingScheduleHour",
                table: "Consulta",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginingScheduleHour",
                table: "Consulta",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndingScheduleHour",
                table: "Consulta",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BeginingScheduleHour",
                table: "Consulta",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "ConsultorioEntity",
                columns: new[] { "Id", "Active", "CreationDate", "MedicalOficceNumber", "Speciality", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("3138c493-ecf2-4831-82a9-192914ee872a"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pediatric Cardiology", null },
                    { new Guid("3402cef6-7ff7-4839-a2ef-b0d99da538ca"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cardiology", null },
                    { new Guid("6b959f19-9057-40a8-a35b-4913c265b8f5"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Neumology", null }
                });
        }
    }
}
