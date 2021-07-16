using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsMeetTutors.Migrations
{
    public partial class ColumnUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassLength",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatienceLevel",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeachingLength",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssimilationRate",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AttentionSpan",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClassLength",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassLength",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "PatienceLevel",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "TeachingLength",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "AssimilationRate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AttentionSpan",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ClassLength",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Students");
        }
    }
}
