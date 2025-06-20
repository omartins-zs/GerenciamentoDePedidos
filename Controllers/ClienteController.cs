using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePedidos.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string busca)
        {
            var clientes = string.IsNullOrEmpty(busca)
                ? _repository.GetAll()
                : _repository.Search(busca);
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            var cliente = _repository.GetById(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Delete(int id)
        {
            var cliente = _repository.GetById(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
