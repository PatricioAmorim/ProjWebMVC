using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebVendasMVC.Models;
using WebVendasMVC.Services;

namespace WebVendasMVC.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedorServices _vendedorSevices;

        public VendedoresController(VendedorServices vendedorServices)
        {
            _vendedorSevices = vendedorServices;
        }



        public IActionResult Index()
        {
            var list = _vendedorSevices.FindAll();
            
            return View(list);
        }


        public IActionResult Create()
        {

            return View();

        }

        [HttpPost][ValidateAntiForgeryToken]
        public IActionResult Create(Vendedores vendedores)
        {

            _vendedorSevices.InsereVendedor(vendedores);
            return RedirectToAction(nameof(Index));

        }

    }

}
