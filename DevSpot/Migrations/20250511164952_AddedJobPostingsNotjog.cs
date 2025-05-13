using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevSpot.Migrations
{
    /// <inheritdoc />
    public partial class AddedJobPostingsNotjog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jogPostings_AspNetUsers_UserId",
                table: "jogPostings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jogPostings",
                table: "jogPostings");

            migrationBuilder.RenameTable(
                name: "jogPostings",
                newName: "JobPostings");

            migrationBuilder.RenameIndex(
                name: "IX_jogPostings_UserId",
                table: "JobPostings",
                newName: "IX_JobPostings_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobPostings",
                table: "JobPostings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPostings_AspNetUsers_UserId",
                table: "JobPostings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPostings_AspNetUsers_UserId",
                table: "JobPostings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobPostings",
                table: "JobPostings");

            migrationBuilder.RenameTable(
                name: "JobPostings",
                newName: "jogPostings");

            migrationBuilder.RenameIndex(
                name: "IX_JobPostings_UserId",
                table: "jogPostings",
                newName: "IX_jogPostings_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jogPostings",
                table: "jogPostings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_jogPostings_AspNetUsers_UserId",
                table: "jogPostings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
