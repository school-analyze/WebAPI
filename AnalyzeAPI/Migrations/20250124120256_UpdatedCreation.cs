using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnalyzeAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_SubjectModelId",
                table: "Grades");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Grades_SubjectModelId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SubjectModelId",
                table: "Grades");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Grades",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Grades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectModelId",
                table: "Grades",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Math" },
                    { 2, "Italian" },
                    { 3, "History" },
                    { 4, "Physical Education" },
                    { 5, "SIR" },
                    { 6, "English" },
                    { 7, "Telecommunication" },
                    { 8, "TPI" },
                    { 9, "Computer Science" },
                    { 10, "Religion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectModelId",
                table: "Grades",
                column: "SubjectModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_SubjectModelId",
                table: "Grades",
                column: "SubjectModelId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
