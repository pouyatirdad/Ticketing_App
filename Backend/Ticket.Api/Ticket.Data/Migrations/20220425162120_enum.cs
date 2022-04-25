using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticket.Data.Migrations
{
    public partial class @enum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConversationID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConversationID",
                table: "Tickets",
                column: "ConversationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Conversations_ConversationID",
                table: "Tickets",
                column: "ConversationID",
                principalTable: "Conversations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Conversations_ConversationID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ConversationID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ConversationID",
                table: "Tickets");
        }
    }
}
