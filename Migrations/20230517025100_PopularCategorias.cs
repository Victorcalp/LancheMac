using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanchesMac.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into categorias (Nome, Descricao)" 
                + "value ('normal', 'lanche feito com ingredientes naturais')");
            migrationBuilder.Sql("insert into categorias (Nome, Descricao)" 
                + "value ('x-salada', 'lanche x-salada')");
            migrationBuilder.Sql("insert into categorias (Nome, Descricao)"
                + "value ('x-bacon', 'lanche x-bacon')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM categorias");
        }
    }
}
