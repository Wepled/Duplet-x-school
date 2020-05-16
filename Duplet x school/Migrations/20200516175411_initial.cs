using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Duplet_x_school.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kabinet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kabinet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    KabinetId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    KabinetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_Kabinet_KabinetId",
                        column: x => x.KabinetId,
                        principalTable: "Kabinet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    SchoolClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OptSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptSubject_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSchoolClassAssignments",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    SchoolClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSchoolClassAssignments", x => new { x.TeacherId, x.SchoolClassId });
                    table.ForeignKey(
                        name: "FK_TeacherSchoolClassAssignments_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSchoolClassAssignments_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSchoolClassEnrollment",
                columns: table => new
                {
                    StudentSchoolClassEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    SchoolClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSchoolClassEnrollment", x => x.StudentSchoolClassEnrollmentId);
                    table.ForeignKey(
                        name: "FK_StudentSchoolClassEnrollment_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSchoolClassEnrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptSubjectEnrollment",
                columns: table => new
                {
                    StudentOptSubjectEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptSubjectId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptSubjectEnrollment", x => x.StudentOptSubjectEnrollmentId);
                    table.ForeignKey(
                        name: "FK_OptSubjectEnrollment_OptSubject_OptSubjectId",
                        column: x => x.OptSubjectId,
                        principalTable: "OptSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptSubjectEnrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptSubjectTeacherAssignment",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    OptSubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptSubjectTeacherAssignment", x => new { x.OptSubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_OptSubjectTeacherAssignment_OptSubject_OptSubjectId",
                        column: x => x.OptSubjectId,
                        principalTable: "OptSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptSubjectTeacherAssignment_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClassSubjectAssignment",
                columns: table => new
                {
                    SchoolClassId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClassSubjectAssignment", x => new { x.SubjectId, x.SchoolClassId });
                    table.ForeignKey(
                        name: "FK_SchoolClassSubjectAssignment_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClassSubjectAssignment_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacherAssignment",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacherAssignment", x => new { x.SubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacherAssignment_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacherAssignment_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptSubject_TeacherId",
                table: "OptSubject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_OptSubjectEnrollment_OptSubjectId",
                table: "OptSubjectEnrollment",
                column: "OptSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OptSubjectEnrollment_StudentId",
                table: "OptSubjectEnrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OptSubjectTeacherAssignment_TeacherId",
                table: "OptSubjectTeacherAssignment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassSubjectAssignment_SchoolClassId",
                table: "SchoolClassSubjectAssignment",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolClassId",
                table: "Student",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSchoolClassEnrollment_SchoolClassId",
                table: "StudentSchoolClassEnrollment",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSchoolClassEnrollment_StudentId",
                table: "StudentSchoolClassEnrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacherAssignment_TeacherId",
                table: "SubjectTeacherAssignment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_KabinetId",
                table: "Teacher",
                column: "KabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchoolClassAssignments_SchoolClassId",
                table: "TeacherSchoolClassAssignments",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchoolClassAssignments_TeacherId",
                table: "TeacherSchoolClassAssignments",
                column: "TeacherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptSubjectEnrollment");

            migrationBuilder.DropTable(
                name: "OptSubjectTeacherAssignment");

            migrationBuilder.DropTable(
                name: "SchoolClassSubjectAssignment");

            migrationBuilder.DropTable(
                name: "StudentSchoolClassEnrollment");

            migrationBuilder.DropTable(
                name: "SubjectTeacherAssignment");

            migrationBuilder.DropTable(
                name: "TeacherSchoolClassAssignments");

            migrationBuilder.DropTable(
                name: "OptSubject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Kabinet");
        }
    }
}
