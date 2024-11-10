using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Classes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentsId",
                table: "Classes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
