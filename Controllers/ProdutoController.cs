using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GerenciamentoDePedidos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _repo;
        public ProdutoController(IProdutoRepository repo) => _repo = repo;

        public IActionResult Index(string filtro)
        {
            var lista = string.IsNullOrEmpty(filtro)
                ? _repo.GetAll(null)
                : _repo.GetAll(filtro);
            return View(lista);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (!ModelState.IsValid) return View(produto);
            _repo.Create(produto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var p = _repo.GetById(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            if (!ModelState.IsValid) return View(produto);
            _repo.Update(produto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var p = _repo.GetById(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}