using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectPromotion.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPromotion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromoDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PromoType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromoDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Store = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    StoreName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
