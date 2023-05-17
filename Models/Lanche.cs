namespace LanchesMac.Models
{
    public class Lanche
    {
        public int LancheId { get; set; }
        public string? Nome { get; set; }
        public string? DescricaoCurta { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public string? ImagemThumbnaiUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }


        //Foreign key - BD -- relaciona Categoria e lanche

        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
    }
}
