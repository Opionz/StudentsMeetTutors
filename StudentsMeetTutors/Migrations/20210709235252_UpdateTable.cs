using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsMeetTutors.Migrations
{
    public partial class UpdateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tutors_TutorID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TutorID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TutorID",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "TeachingStyle",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LearningStyle",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StudentRecordTutorRecord",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TutorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRecordTutorRecord", x => new { x.StudentID, x.TutorID });
                    table.ForeignKey(
                        name: "FK_StudentRecordTutorRecord_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRecordTutorRecord_Tutors_TutorID",
                        column: x => x.TutorID,
                        principalTable: "Tutors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentRecordTutorRecord_TutorID",
                table: "StudentRecordTutorRecord",
                column: "TutorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentRecordTutorRecord");

            migrationBuilder.DropColumn(
                name: "TeachingStyle",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "LearningStyle",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "TutorID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TutorID",
                table: "Students",
                column: "TutorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tutors_TutorID",
                table: "Students",
                column: "TutorID",
                principalTable: "Tutors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
