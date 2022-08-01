using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authority_Worker_WorkerID",
                table: "Authority");

            migrationBuilder.DropIndex(
                name: "IX_Authority_WorkerID",
                table: "Authority");

            migrationBuilder.DropColumn(
                name: "WorkerID",
                table: "Authority");

            migrationBuilder.AddColumn<int>(
                name: "AuthorityID",
                table: "Worker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_AuthorityID",
                table: "Worker",
                column: "AuthorityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Authority_AuthorityID",
                table: "Worker",
                column: "AuthorityID",
                principalTable: "Authority",
                principalColumn: "AuthrorityID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Authority_AuthorityID",
                table: "Worker");

            migrationBuilder.DropIndex(
                name: "IX_Worker_AuthorityID",
                table: "Worker");

            migrationBuilder.DropColumn(
                name: "AuthorityID",
                table: "Worker");

            migrationBuilder.AddColumn<int>(
                name: "WorkerID",
                table: "Authority",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Authority_WorkerID",
                table: "Authority",
                column: "WorkerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Authority_Worker_WorkerID",
                table: "Authority",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "WorkerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
