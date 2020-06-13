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
                name: "OptSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptSubject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClass",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    IDCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClassKabinetAssignment",
                columns: table => new
                {
                    SchoolClassId = table.Column<int>(nullable: false),
                    KabinetId = table.Column<int>(nullable: false),
                    SchoolClassKabinetAssignmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClassKabinetAssignment", x => new { x.SchoolClassId, x.KabinetId });
                    table.ForeignKey(
                        name: "FK_SchoolClassKabinetAssignment_Kabinet_KabinetId",
                        column: x => x.KabinetId,
                        principalTable: "Kabinet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClassKabinetAssignment_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentOptSubjectEnrollment",
                columns: table => new
                {
                    StudentOptSubjectEnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptSubjectId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOptSubjectEnrollment", x => x.StudentOptSubjectEnrollmentId);
                    table.ForeignKey(
                        name: "FK_StudentOptSubjectEnrollment_OptSubject_OptSubjectId",
                        column: x => x.OptSubjectId,
                        principalTable: "OptSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentOptSubjectEnrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
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
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
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

            migrationBuilder.CreateTable(
                name: "TeacherKabinetAssignment",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    KabinetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherKabinetAssignment", x => new { x.TeacherId, x.KabinetId });
                    table.ForeignKey(
                        name: "FK_TeacherKabinetAssignment_Kabinet_KabinetId",
                        column: x => x.KabinetId,
                        principalTable: "Kabinet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherKabinetAssignment_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherOptSubjectAssignment",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    OptSubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherOptSubjectAssignment", x => new { x.OptSubjectId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_TeacherOptSubjectAssignment_OptSubject_OptSubjectId",
                        column: x => x.OptSubjectId,
                        principalTable: "OptSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherOptSubjectAssignment_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSchoolClassAssignment",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false),
                    SchoolClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSchoolClassAssignment", x => new { x.TeacherId, x.SchoolClassId });
                    table.ForeignKey(
                        name: "FK_TeacherSchoolClassAssignment_SchoolClass_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSchoolClassAssignment_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId",
                table: "Grades",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectId",
                table: "Grades",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassKabinetAssignment_KabinetId",
                table: "SchoolClassKabinetAssignment",
                column: "KabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassKabinetAssignment_SchoolClassId",
                table: "SchoolClassKabinetAssignment",
                column: "SchoolClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassSubjectAssignment_SchoolClassId",
                table: "SchoolClassSubjectAssignment",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOptSubjectEnrollment_OptSubjectId",
                table: "StudentOptSubjectEnrollment",
                column: "OptSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOptSubjectEnrollment_StudentId",
                table: "StudentOptSubjectEnrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSchoolClassEnrollment_SchoolClassId",
                table: "StudentSchoolClassEnrollment",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSchoolClassEnrollment_StudentId",
                table: "StudentSchoolClassEnrollment",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacherAssignment_TeacherId",
                table: "SubjectTeacherAssignment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherKabinetAssignment_KabinetId",
                table: "TeacherKabinetAssignment",
                column: "KabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherKabinetAssignment_TeacherId",
                table: "TeacherKabinetAssignment",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherOptSubjectAssignment_TeacherId",
                table: "TeacherOptSubjectAssignment",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchoolClassAssignment_SchoolClassId",
                table: "TeacherSchoolClassAssignment",
                column: "SchoolClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSchoolClassAssignment_TeacherId",
                table: "TeacherSchoolClassAssignment",
                column: "TeacherId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "SchoolClassKabinetAssignment");

            migrationBuilder.DropTable(
                name: "SchoolClassSubjectAssignment");

            migrationBuilder.DropTable(
                name: "StudentOptSubjectEnrollment");

            migrationBuilder.DropTable(
                name: "StudentSchoolClassEnrollment");

            migrationBuilder.DropTable(
                name: "SubjectTeacherAssignment");

            migrationBuilder.DropTable(
                name: "TeacherKabinetAssignment");

            migrationBuilder.DropTable(
                name: "TeacherOptSubjectAssignment");

            migrationBuilder.DropTable(
                name: "TeacherSchoolClassAssignment");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Kabinet");

            migrationBuilder.DropTable(
                name: "OptSubject");

            migrationBuilder.DropTable(
                name: "SchoolClass");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
