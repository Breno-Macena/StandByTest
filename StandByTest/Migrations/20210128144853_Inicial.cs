using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StandByTest.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razao_social = table.Column<string>(type: "varchar", nullable: false),
                    data_fundacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cnpj = table.Column<string>(type: "varchar", nullable: true),
                    capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quarentena = table.Column<bool>(type: "bit", nullable: false),
                    status_cliente = table.Column<bool>(type: "bit", nullable: false),
                    classificacao = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
