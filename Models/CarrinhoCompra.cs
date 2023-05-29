using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private protected MySQLContext _context;

        public CarrinhoCompra(MySQLContext context) {

            _context = context;
        }

        public int Id { get; set; }
        public Lanche Lanche{ get; set; }
        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {

            //Define uma Sessão, ? avalia se o IHttpContextAccessor é null, se ele for diferente de null ele obtem uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; 

            //Obtem um serviço do tipo contexto
            var context = services.GetService<MySQLContext>();

            //Obtem ou gera o ID do carrinho, se for diferente de Null ele gera novo valor pelo Guid
            // ?? operador de coalescência nula
            string carrinhoId = session.GetString("Id")??Guid.NewGuid().ToString();

            //Atribui o ID do carrinho na sessão
            session.SetString("Id", carrinhoId);

            //Retorna o carrinho com o contexto e o ID atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };

        }
    }
}
