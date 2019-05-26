using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mvc01.Migrations
{
    public partial class update06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Home_Line1 = table.Column<string>(nullable: true),
                    Home_Line2 = table.Column<string>(nullable: true),
                    Home_Line3 = table.Column<string>(nullable: true),
                    Home_Province = table.Column<string>(nullable: true),
                    Home_PostalCode = table.Column<string>(nullable: true),
                    Office_Line1 = table.Column<string>(nullable: true),
                    Office_Line2 = table.Column<string>(nullable: true),
                    Office_Line3 = table.Column<string>(nullable: true),
                    Office_Province = table.Column<string>(nullable: true),
                    Office_PostalCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
