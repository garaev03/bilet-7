using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingSocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SettingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingSocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingSocialMedias_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Logo" },
                values: new object[] { 1, "Studio" });

            migrationBuilder.CreateIndex(
                name: "IX_SettingSocialMedias_SettingId",
                table: "SettingSocialMedias",
                column: "SettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingSocialMedias");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
