using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpecialPrograms2Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HalqaPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HalqaPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GuardianPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialStudents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialHalqas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    SessionTypeId = table.Column<int>(type: "int", nullable: false),
                    SessionTimeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialHalqas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialHalqas_HalqaPrograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "HalqaPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialHalqas_SessionTimes_SessionTimeId",
                        column: x => x.SessionTimeId,
                        principalTable: "SessionTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialHalqas_SessionTypes_SessionTypeId",
                        column: x => x.SessionTypeId,
                        principalTable: "SessionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HalqaAuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HalqaId = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PerformedBy = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HalqaAuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HalqaAuditLogs_SpecialHalqas_HalqaId",
                        column: x => x.HalqaId,
                        principalTable: "SpecialHalqas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialHalqatStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    HalqaId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UnassignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MovedToHalqa = table.Column<int>(type: "int", nullable: true),
                    MovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialHalqatStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialHalqatStudents_SpecialHalqas_HalqaId",
                        column: x => x.HalqaId,
                        principalTable: "SpecialHalqas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialHalqatStudents_SpecialStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "SpecialStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialHalqatTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    HalqaId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UnassignedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialHalqatTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialHalqatTeachers_SpecialHalqas_HalqaId",
                        column: x => x.HalqaId,
                        principalTable: "SpecialHalqas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialStudentEvaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    HalqaId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StartSurahId = table.Column<int>(type: "int", nullable: false),
                    StartAyah = table.Column<int>(type: "int", nullable: false),
                    EndSurahId = table.Column<int>(type: "int", nullable: false),
                    EndAyah = table.Column<int>(type: "int", nullable: false),
                    TotalLines = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPages = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalParts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EvaluationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EvaluationScore = table.Column<byte>(type: "tinyint", nullable: false),
                    ReviewScore = table.Column<int>(type: "int", nullable: false),
                    LessonStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialStudentEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialStudentEvaluations_SpecialHalqas_HalqaId",
                        column: x => x.HalqaId,
                        principalTable: "SpecialHalqas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialStudentEvaluations_SpecialStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "SpecialStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HalqaAuditLogs_HalqaId",
                table: "HalqaAuditLogs",
                column: "HalqaId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialHalqas_ProgramId",
                table: "SpecialHalqas",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialHalqas_SessionTimeId",
                table: "SpecialHalqas",
                column: "SessionTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialHalqas_SessionTypeId",
                table: "SpecialHalqas",
                column: "SessionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialHalqatStudents_HalqaId",
                table: "SpecialHalqatStudents",
                column: "HalqaId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialHalqatStudents_StudentId",
                table: "SpecialHalqatStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialHalqatTeachers_HalqaId",
                table: "SpecialHalqatTeachers",
                column: "HalqaId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialStudentEvaluations_HalqaId",
                table: "SpecialStudentEvaluations",
                column: "HalqaId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialStudentEvaluations_StudentId",
                table: "SpecialStudentEvaluations",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HalqaAuditLogs");

            migrationBuilder.DropTable(
                name: "SpecialHalqatStudents");

            migrationBuilder.DropTable(
                name: "SpecialHalqatTeachers");

            migrationBuilder.DropTable(
                name: "SpecialStudentEvaluations");

            migrationBuilder.DropTable(
                name: "SpecialHalqas");

            migrationBuilder.DropTable(
                name: "SpecialStudents");

            migrationBuilder.DropTable(
                name: "HalqaPrograms");

            migrationBuilder.DropTable(
                name: "SessionTimes");

            migrationBuilder.DropTable(
                name: "SessionTypes");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");
        }
    }
}
