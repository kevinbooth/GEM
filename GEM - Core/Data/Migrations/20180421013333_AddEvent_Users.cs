using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GEM.Data.Migrations
{
    public partial class AddEvent_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event_Users",
                columns: table => new
                {
                    Event = table.Column<Guid>(nullable: false),
                    User = table.Column<string>(nullable: false, maxLength: 256)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_User", x => new { x.Event, x.User });
                    table.ForeignKey("FK_Event_User_Event", x => x.Event, "Events", "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event_Users");
        }
    }
}
