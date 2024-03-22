using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMFG.MinhaPrimeira.API.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUnificada_1_0_0_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    CD_EAN = table.Column<string>(type: "longtext", nullable: false),
                    DS_PRODUTO = table.Column<string>(type: "longtext", nullable: false),
                    VL_CUSTO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VL_VENDA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DS_USUARIO_CADASTRO = table.Column<string>(type: "longtext", nullable: false),
                    DS_USUARIO_ALTERACAO = table.Column<string>(type: "longtext", nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DT_ALTERACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTO");
        }
    }
}
