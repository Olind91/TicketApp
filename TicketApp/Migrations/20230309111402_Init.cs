using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Comment_CommentId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_CommentId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Ticket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CommentId",
                table: "Ticket",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Comment_CommentId",
                table: "Ticket",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
