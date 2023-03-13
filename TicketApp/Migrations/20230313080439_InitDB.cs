using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApp.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CustomerLastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "char(13)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TicketEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Ticket_TicketEntityId",
                        column: x => x.TicketEntityId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TicketEntityId",
                table: "Comment",
                column: "TicketEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
