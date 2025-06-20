using GerenciamentoDePedidos.Domain.Models;
using GerenciamentoDePedidos.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePedidos.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _orderRepo;
        private readonly IClienteRepository _clientRepo;
        private readonly IProdutoRepository _productRepo;

        public PedidoController(
            IPedidoRepository orderRepo,
            IClienteRepository clientRepo,
            IProdutoRepository productRepo)
        {
            _orderRepo = orderRepo;
            _clientRepo = clientRepo;
            _productRepo = productRepo;
        }

        public IActionResult Index(int? clienteId, string status)
        {
            ViewBag.Clientes = _clientRepo.GetAll();
            return View(_orderRepo.GetAll(clienteId, status));
        }

        public IActionResult Create()
        {
            ViewBag.Clientes = _clientRepo.GetAll();
            ViewBag.Produtos = _productRepo.GetAll(null);
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = _clientRepo.GetAll();
                ViewBag.Produtos = _productRepo.GetAll(null);
                return View(pedido);
            }

            _orderRepo.Create(pedido);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var pedido = _orderRepo.GetById(id);
            if (pedido == null) return NotFound();
            return View(pedido);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            _orderRepo.UpdateStatus(id, status);
            return RedirectToAction("Details", new { id });
        }
    }
}
