using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dariabarinovakt4120.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    directionid = table.Column<int>(name: "direction_id", type: "int", nullable: false, comment: "ID направления")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    directionname = table.Column<string>(name: "direction_name", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название направления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_direction_direction_id", x => x.directionid);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    subjectid = table.Column<int>(name: "subject_id", type: "int", nullable: false, comment: "ID предмета")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sudjectname = table.Column<string>(name: "sudject_name", type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название предмета"),
                    directionid = table.Column<int>(name: "direction_id", type: "int", nullable: false, comment: "ID направления"),
                    isdeleted = table.Column<bool>(name: "is_deleted", type: "bit", nullable: false, comment: "Статус удаления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject_subject_id", x => x.subjectid);
                    table.ForeignKey(
                        name: "fk_f_direction_id",
                        column: x => x.directionid,
                        principalTable: "Directions",
                        principalColumn: "direction_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_subject_fk_f_direction_id",
                table: "subject",
                column: "direction_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "Directions");
        }
    }
}
