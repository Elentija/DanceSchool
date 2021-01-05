using Microsoft.EntityFrameworkCore.Migrations;

namespace DanceSchool.Server.Migrations
{
    public partial class AddCoachId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Coaches_CoachId",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Trainings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Coaches_CoachId",
                table: "Trainings",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Coaches_CoachId",
                table: "Trainings");

            migrationBuilder.AlterColumn<int>(
                name: "CoachId",
                table: "Trainings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Coaches_CoachId",
                table: "Trainings",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
