using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Consultorio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingApoinmentLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("0a4773f8-5af7-4d4b-afb8-f3ec28a3daea"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("88699d8c-e3a2-413b-81ba-f91cb24c29ba"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("d9f413b2-d4d2-482a-b7dd-d15557955935"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Appoinmentlength",
                table: "Consulta",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Appoinmentlength",
                table: "Consulta",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "ConsultorioEntity",
                columns: new[] { "Id", "Active", "CreationDate", "MedicalOficceNumber", "Speciality", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0a4773f8-5af7-4d4b-afb8-f3ec28a3daea"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Neumology", null },
                    { new Guid("88699d8c-e3a2-413b-81ba-f91cb24c29ba"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pediatric Cardiology", null },
                    { new Guid("d9f413b2-d4d2-482a-b7dd-d15557955935"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cardiology", null }
                });
        }
    }
}
