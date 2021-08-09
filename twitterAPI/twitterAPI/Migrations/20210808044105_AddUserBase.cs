using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace twitterAPI.Migrations
{
    public partial class AddUserBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Twitter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "DateCreated", "DateModified", "Email", "Name", "Password" },
                values: new object[] { -1, new DateTime(2021, 8, 8, 4, 41, 5, 191, DateTimeKind.Utc).AddTicks(7061), new DateTime(2021, 8, 8, 4, 41, 5, 191, DateTimeKind.Utc).AddTicks(7315), "admin@email.com", "admin", "admin123" });

            migrationBuilder.CreateIndex(
                name: "IX_Twitter_UserID",
                table: "Twitter",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Twitter_User_UserID",
                table: "Twitter",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Twitter_User_UserID",
                table: "Twitter");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Twitter_UserID",
                table: "Twitter");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Twitter");
        }
    }
}
