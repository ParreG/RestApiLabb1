using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiLabb1.Migrations
{
    /// <inheritdoc />
    public partial class idChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_PersonalInfos_PersonalInfoId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExperiences_PersonalInfos_PersonalInfoId",
                table: "JobExperiences");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PersonalInfos",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId",
                table: "JobExperiences",
                newName: "PersonalInfoId_Fk");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "JobExperiences",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_JobExperiences_PersonalInfoId",
                table: "JobExperiences",
                newName: "IX_JobExperiences_PersonalInfoId_Fk");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId",
                table: "Educations",
                newName: "PersonalInfoId_Fk");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Educations",
                newName: "EducationId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_PersonalInfoId",
                table: "Educations",
                newName: "IX_Educations_PersonalInfoId_Fk");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_PersonalInfos_PersonalInfoId_Fk",
                table: "Educations",
                column: "PersonalInfoId_Fk",
                principalTable: "PersonalInfos",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperiences_PersonalInfos_PersonalInfoId_Fk",
                table: "JobExperiences",
                column: "PersonalInfoId_Fk",
                principalTable: "PersonalInfos",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_PersonalInfos_PersonalInfoId_Fk",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExperiences_PersonalInfos_PersonalInfoId_Fk",
                table: "JobExperiences");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "PersonalInfos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId_Fk",
                table: "JobExperiences",
                newName: "PersonalInfoId");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "JobExperiences",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_JobExperiences_PersonalInfoId_Fk",
                table: "JobExperiences",
                newName: "IX_JobExperiences_PersonalInfoId");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId_Fk",
                table: "Educations",
                newName: "PersonalInfoId");

            migrationBuilder.RenameColumn(
                name: "EducationId",
                table: "Educations",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_PersonalInfoId_Fk",
                table: "Educations",
                newName: "IX_Educations_PersonalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_PersonalInfos_PersonalInfoId",
                table: "Educations",
                column: "PersonalInfoId",
                principalTable: "PersonalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperiences_PersonalInfos_PersonalInfoId",
                table: "JobExperiences",
                column: "PersonalInfoId",
                principalTable: "PersonalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
