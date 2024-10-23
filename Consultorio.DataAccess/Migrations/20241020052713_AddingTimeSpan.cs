using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Consultorio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingTimeSpan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("2ddb8d8e-09f0-47a3-af09-390fb70df5cb"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("8a97343d-813b-4ef9-8df2-6d254f052736"));

            migrationBuilder.DeleteData(
                table: "ConsultorioEntity",
                keyColumn: "Id",
                keyValue: new Guid("8b599cb7-1498-4516-b997-7ad59c2e80c2"));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Appoinmentlength",
                table: "Consulta",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Appoinmentlength",
                table: "Consulta");

            migrationBuilder.InsertData(
                table: "ConsultorioEntity",
                columns: new[] { "Id", "Active", "CreationDate", "MedicalOficceNumber", "Speciality", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2ddb8d8e-09f0-47a3-af09-390fb70df5cb"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cardiology", null },
                    { new Guid("8a97343d-813b-4ef9-8df2-6d254f052736"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pediatric Cardiology", null },
                    { new Guid("8b599cb7-1498-4516-b997-7ad59c2e80c2"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Neumology", null }
                });
        }
    }
}
