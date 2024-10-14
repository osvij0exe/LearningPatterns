using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Consultorio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultorioEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalOficceNumber = table.Column<int>(type: "int", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultorioEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FamilyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Practitioner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FamilyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practitioner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleDay = table.Column<DateTime>(type: "Date", nullable: false),
                    BeginingScheduleHour = table.Column<DateTime>(type: "Date", nullable: false),
                    EndingScheduleHour = table.Column<DateTime>(type: "Date", nullable: false),
                    PractitionerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultorioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_ConsultorioEntity_ConsultorioId",
                        column: x => x.ConsultorioId,
                        principalTable: "ConsultorioEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Practitioner_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "Practitioner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConsultorioEntity",
                columns: new[] { "Id", "Active", "CreationDate", "MedicalOficceNumber", "Speciality", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2ddb8d8e-09f0-47a3-af09-390fb70df5cb"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cardiology", null },
                    { new Guid("8a97343d-813b-4ef9-8df2-6d254f052736"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Pediatric Cardiology", null },
                    { new Guid("8b599cb7-1498-4516-b997-7ad59c2e80c2"), true, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Neumology", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ConsultorioId",
                table: "Consulta",
                column: "ConsultorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PatientId",
                table: "Consulta",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PractitionerId",
                table: "Consulta",
                column: "PractitionerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "ConsultorioEntity");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Practitioner");
        }
    }
}
