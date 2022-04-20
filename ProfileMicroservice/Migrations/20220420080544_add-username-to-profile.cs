using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfileMicroservice.Migrations
{
    public partial class addusernametoprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Profiles");
        }
    }
}
