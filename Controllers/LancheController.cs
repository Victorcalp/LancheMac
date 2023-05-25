using LanchesMac.Repository.Interface;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchesRepository _repository;

        public LancheController(ILanchesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult List()
        {
            //var lanche = _repository.Lanches;
            //return View(lanche);
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _repository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";
            return View(lancheListViewModel);
        }
    }
}
