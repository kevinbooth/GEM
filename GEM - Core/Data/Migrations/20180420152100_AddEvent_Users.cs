using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using GEM.Models;
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
                    User = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_User", x => new { x.Event, x.User });
                    table.ForeignKey("FK_Event", x => x.Event, "Events", "Id");
                    table.ForeignKey("FK_User", x => x.User, "Users", "Id");
                }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event_Users");
        }
    }
}
