using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProvaQuestorCSharp.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Codigo = table.Column<int>(type: "integer", nullable: false),
                    PercentualJuros = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boleto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomePagador = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CpfPagador = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    CnpjPagador = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    NomeBeneficiario = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CpfBeneficiario = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    CnpjBeneficiario = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Observacao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BancoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boleto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Boleto");
        }
    }
}
