using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studio.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingSocialMedias");

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedinLink",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FacebookLink", "LinkedinLink", "TwitterLink" },
                values: new object[] { "Facebook", "Linkedin", "Twitter" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LinkedinLink",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "Settings");

            migrationBuilder.CreateTable(
                name: "SettingSocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_SettingSocialMedias_SettingId",
                table: "SettingSocialMedias",
                column: "SettingId");
        }
    }
}
