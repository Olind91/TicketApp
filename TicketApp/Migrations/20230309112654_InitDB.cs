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
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Status_StatusId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_StatusId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Complete",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "InProgress",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "NotStarted",
                table: "Status");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Ticket",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Status");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Ticket",
                newName: "StatusId");

            migrationBuilder.AddColumn<string>(
                name: "Complete",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InProgress",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NotStarted",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_StatusId",
                table: "Ticket",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Status_StatusId",
                table: "Ticket",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
