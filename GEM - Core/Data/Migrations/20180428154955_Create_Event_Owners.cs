using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GEM.Data.Migrations
{
    public partial class Create_Event_Owners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event_Owners",
                columns: table => new
                {
                    Event = table.Column<Guid>(nullable: false),
                    Owner = table.Column<string>(nullable: false, maxLength: 256)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Owner", x => new { x.Event, x.Owner });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event_Owners");
        }
    }
}
