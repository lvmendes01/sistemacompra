using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class createtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NomeFornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomeFornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Categoria = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSolicitantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSolicitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoCompra",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioSolicitanteId = table.Column<Guid>(nullable: true),
                    NomeFornecedorId = table.Column<Guid>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    TotalGeral = table.Column<decimal>(nullable: false),
                    Situacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacaoCompra_NomeFornecedores_NomeFornecedorId",
                        column: x => x.NomeFornecedorId,
                        principalTable: "NomeFornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacaoCompra_UsuarioSolicitantes_UsuarioSolicitanteId",
                        column: x => x.UsuarioSolicitanteId,
                        principalTable: "UsuarioSolicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: true),
                    Qtde = table.Column<int>(nullable: false),
                    SolicitacaoCompraId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_SolicitacaoCompra_SolicitacaoCompraId",
                        column: x => x.SolicitacaoCompraId,
                        principalTable: "SolicitacaoCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("9cfbce02-1c7a-4f05-97c8-52ccfa230bdf"), 1, "Descricao01", "Produto01", 100m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProdutoId",
                table: "Items",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SolicitacaoCompraId",
                table: "Items",
                column: "SolicitacaoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_NomeFornecedorId",
                table: "SolicitacaoCompra",
                column: "NomeFornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoCompra_UsuarioSolicitanteId",
                table: "SolicitacaoCompra",
                column: "UsuarioSolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "SolicitacaoCompra");

            migrationBuilder.DropTable(
                name: "NomeFornecedores");

            migrationBuilder.DropTable(
                name: "UsuarioSolicitantes");
        }
    }
}
