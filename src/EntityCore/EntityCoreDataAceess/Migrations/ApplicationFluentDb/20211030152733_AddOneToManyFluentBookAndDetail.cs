using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityCoreDataAceess.Migrations.ApplicationFluentDb
{
    public partial class AddOneToManyFluentBookAndDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FluentPublisher_Id",
                table: "FluentBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_FluentPublisher_Id",
                table: "FluentBooks",
                column: "FluentPublisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentPublishers_FluentPublisher_Id",
                table: "FluentBooks",
                column: "FluentPublisher_Id",
                principalTable: "FluentPublishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentPublishers_FluentPublisher_Id",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_FluentPublisher_Id",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "FluentPublisher_Id",
                table: "FluentBooks");
        }
    }
}
