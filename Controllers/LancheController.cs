using LanchesMac.Repository.Interface;
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
            var lanche = _repository.Lanches;
            return View(lanche);
        }
    }
}
