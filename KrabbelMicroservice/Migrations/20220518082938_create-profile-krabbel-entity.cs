using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrabbelMicroservice.Migrations
{
    /// <inheritdoc />
    public partial class createprofilekrabbelentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileKrabbels",
                columns: table => new
                {
                    KrabbelId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToProfileId = table.Column<long>(type: "bigint", nullable: false),
                    FromProfileId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileKrabbels", x => x.KrabbelId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileKrabbels");
        }
    }
}
