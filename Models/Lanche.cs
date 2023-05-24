using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        //ErrorMessage - consegue alterar o erro que aparece para o usuario

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} de ter no minimo {1} e no maximo {2} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descriação do lanche deve ser informada")]
        [Display(Name = "Descrição Resumida")]
        [MinLength(20, ErrorMessage = "Descriação deve ter no minimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no maximo {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição deve ser informada")]
        [Display(Name = "Descrição Detalhada")]
        [StringLength(200, MinimumLength = 50, ErrorMessage = "Informe a descrição detalhada")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o Preço")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")] // definiu como decimal, com 10 digitos e 2 casas decimais
        [Range(1, 999.999, ErrorMessage = "O Preço deve estar entre 1 e 999,999")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho da imagem normal")]
        [StringLength(200)]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho da imagem miniatura")]
        [StringLength(200)]
        public string ImagemThumbnaiUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }


        //Foreign key - BD -- relaciona Categoria e lanche

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
