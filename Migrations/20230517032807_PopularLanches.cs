using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class PopularLanches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into lanches (Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnaiUrl, IsLanchePreferido, EmEstoque, CategoriaId)" + 
            "value('x-burguer', 'Hamburguer com pão', 'Hamburguer, ovo e pão', 50.0, '/images/hamburguer-sanduiche-lanche.jpg', '/images/hamburguer-sanduiche-lanche.jpg', 0, 1, 1)");

            migrationBuilder.Sql("insert into lanches (Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnaiUrl, IsLanchePreferido, EmEstoque, CategoriaId)" +
            "value('x-sala', 'Hamburguer com pão com salada', 'Hamburguer, ovo, salada e pão', 70.0, '/images/x-salada-classico.jpg', '/images/x-salada-classico.jpg', 1, 1, 2)");

            migrationBuilder.Sql("insert into lanches (Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnaiUrl, IsLanchePreferido, EmEstoque, CategoriaId)" +
            "value('Sanduiche Natural', 'Pão de forma com maionese e peito de peru', 'Pão de forma com maionese, peito de peru e cenoura', 20.0, '/images/Sanduiche-Natural.jpg', '/images/Sanduiche-Natural.jpg', 1, 1, 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM lanches");
        }
    }
}
