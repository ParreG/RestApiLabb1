using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiLabb1.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_PersonalInfo_PersonalInfoId_Fk",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExperiences_PersonalInfo_PersonalInfoId_Fk",
                table: "JobExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInfo",
                table: "PersonalInfo");

            migrationBuilder.RenameTable(
                name: "PersonalInfo",
                newName: "PersonalInfos");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId_Fk",
                table: "JobExperiences",
                newName: "PersonalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_JobExperiences_PersonalInfoId_Fk",
                table: "JobExperiences",
                newName: "IX_JobExperiences_PersonalInfoId");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId_Fk",
                table: "Educations",
                newName: "PersonalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_PersonalInfoId_Fk",
                table: "Educations",
                newName: "IX_Educations_PersonalInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInfos",
                table: "PersonalInfos",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_PersonalInfos_PersonalInfoId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_JobExperiences_PersonalInfos_PersonalInfoId",
                table: "JobExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInfos",
                table: "PersonalInfos");

            migrationBuilder.RenameTable(
                name: "PersonalInfos",
                newName: "PersonalInfo");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId",
                table: "JobExperiences",
                newName: "PersonalInfoId_Fk");

            migrationBuilder.RenameIndex(
                name: "IX_JobExperiences_PersonalInfoId",
                table: "JobExperiences",
                newName: "IX_JobExperiences_PersonalInfoId_Fk");

            migrationBuilder.RenameColumn(
                name: "PersonalInfoId",
                table: "Educations",
                newName: "PersonalInfoId_Fk");

            migrationBuilder.RenameIndex(
                name: "IX_Educations_PersonalInfoId",
                table: "Educations",
                newName: "IX_Educations_PersonalInfoId_Fk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInfo",
                table: "PersonalInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_PersonalInfo_PersonalInfoId_Fk",
                table: "Educations",
                column: "PersonalInfoId_Fk",
                principalTable: "PersonalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobExperiences_PersonalInfo_PersonalInfoId_Fk",
                table: "JobExperiences",
                column: "PersonalInfoId_Fk",
                principalTable: "PersonalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
