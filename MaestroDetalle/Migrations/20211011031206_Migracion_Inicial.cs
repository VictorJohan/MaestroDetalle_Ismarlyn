using Microsoft.EntityFrameworkCore.Migrations;

namespace MaestroDetalle.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armarios",
                columns: table => new
                {
                    ArmarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armarios", x => x.ArmarioId);
                });

            migrationBuilder.CreateTable(
                name: "Zapatos",
                columns: table => new
                {
                    ZapatoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marca = table.Column<string>(type: "TEXT", nullable: true),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Size = table.Column<float>(type: "REAL", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zapatos", x => x.ZapatoId);
                });

            migrationBuilder.CreateTable(
                name: "ArmarioDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArmarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    ZapatoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmarioDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmarioDetalle_Armarios_ArmarioId",
                        column: x => x.ArmarioId,
                        principalTable: "Armarios",
                        principalColumn: "ArmarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmarioDetalle_Zapatos_ZapatoId",
                        column: x => x.ZapatoId,
                        principalTable: "Zapatos",
                        principalColumn: "ZapatoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmarioDetalle_ArmarioId",
                table: "ArmarioDetalle",
                column: "ArmarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmarioDetalle_ZapatoId",
                table: "ArmarioDetalle",
                column: "ZapatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmarioDetalle");

            migrationBuilder.DropTable(
                name: "Armarios");

            migrationBuilder.DropTable(
                name: "Zapatos");
        }
    }
}
