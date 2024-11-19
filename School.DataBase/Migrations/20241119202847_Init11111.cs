using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Init11111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Discipline_DisciplinesId",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Discipline_DisciplineId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline");

            migrationBuilder.RenameTable(
                name: "Discipline",
                newName: "Disciplines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Disciplines_DisciplinesId",
                table: "DisciplineTeacher",
                column: "DisciplinesId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Disciplines_DisciplineId",
                table: "Schedules",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisciplineTeacher_Disciplines_DisciplinesId",
                table: "DisciplineTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Disciplines_DisciplineId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines");

            migrationBuilder.RenameTable(
                name: "Disciplines",
                newName: "Discipline");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplineTeacher_Discipline_DisciplinesId",
                table: "DisciplineTeacher",
                column: "DisciplinesId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Discipline_DisciplineId",
                table: "Schedules",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
