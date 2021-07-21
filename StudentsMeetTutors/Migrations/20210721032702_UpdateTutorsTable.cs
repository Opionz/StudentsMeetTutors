using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsMeetTutors.Migrations
{
    public partial class UpdateTutorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Review",
                table: "Tutors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
