using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private protected MySQLContext _context;
        public CarrinhoCompra(MySQLContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {

            //Define uma Sessão, ? avalia se o IHttpContextAccessor é null, se ele for diferente de null ele obtem uma sessão
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem um serviço do tipo contexto
            var context = services.GetService<MySQLContext>();

            //Obtem ou gera o ID do carrinho, se for diferente de Null ele gera novo valor pelo Guid
            // ?? operador de coalescência nula
            string carrinhoId = session.GetString("Id") ?? Guid.NewGuid().ToString();

            //Atribui o ID do carrinho na sessão
            session.SetString("Id", carrinhoId);

            //Retorna o carrinho com o contexto e o ID atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }
        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                        s => s.Lanche.LancheId == lanche.LancheId &&
                        s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    Id = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public void RemoverCarrinho(Lanche lanche)
        {
            //pesquisa
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(s => s.Lanche.LancheId == lanche.LancheId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _context.SaveChanges();
        }

        public List<CarrinhoCompraItem>GetCarrinhoCompraItems()
        {
            //retorna Carrinho se não for igual a null, caso seja ele vai avaliar a expressão
            return CarrinhoCompraItens ?? _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Include(s => s.Lanche).ToList();
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId);
            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            return _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Select(c => c.Lanche.Preco * c.Quantidade).Sum();
        }
    }
}