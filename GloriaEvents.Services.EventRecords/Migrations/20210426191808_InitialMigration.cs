﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GloriaEvents.Services.EventComponent.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), "Concerts" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"), "Musicals" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea316"), "Plays" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea317"), "John Egbert", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTime(2021, 10, 26, 20, 18, 7, 501, DateTimeKind.Local).AddTicks(6533), "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", "/img/banjo.jpg", "John Egbert Live", 65 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea319"), "Michael Johnson", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea314"), new DateTime(2022, 1, 26, 20, 18, 7, 503, DateTimeKind.Local).AddTicks(7104), "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?", "/img/michael.jpg", "The State of Affairs: Michael Live!", 85 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { new Guid("cfb88e29-4744-48c0-94fa-b25b92dea318"), "Nick Sailor", new Guid("cfb88e29-4744-48c0-94fa-b25b92dea315"), new DateTime(2021, 12, 26, 20, 18, 7, 503, DateTimeKind.Local).AddTicks(7248), "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.", "/img/musical.jpg", "To the Moon and Back", 135 });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
