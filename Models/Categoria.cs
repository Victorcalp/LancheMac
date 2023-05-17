using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Deve se informar o nome da categoria")]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição")]
        [StringLength (200, ErrorMessage = "Deve ter no maximo 200 caracteres")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        public List<Lanche>? Lanches { get; set; }
    }
}
