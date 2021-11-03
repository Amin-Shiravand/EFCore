using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityCoreDataAceess.Migrations.ApplicationFluentDb
{
    public partial class AddOneToOneFluentBookAndDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookDetail_Id",
                table: "FluentBookDetails",
                newName: "FluentBookDetail_Id");

            migrationBuilder.AddColumn<int>(
                name: "FluentBookDetail_Id",
                table: "FluentBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_FluentBookDetail_Id",
                table: "FluentBooks",
                column: "FluentBookDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_FluentBookDetail_Id",
                table: "FluentBooks",
                column: "FluentBookDetail_Id",
                principalTable: "FluentBookDetails",
                principalColumn: "FluentBookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_FluentBookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_FluentBookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "FluentBookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.RenameColumn(
                name: "FluentBookDetail_Id",
                table: "FluentBookDetails",
                newName: "BookDetail_Id");
        }
    }
}
