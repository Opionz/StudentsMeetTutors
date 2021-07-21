using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsMeetTutors.Migrations
{
    public partial class UpdateTutors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LectureDate",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LectureTime",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TutorRating",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LectureDate",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "LectureTime",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "TutorRating",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Tutors");
        }
    }
}
