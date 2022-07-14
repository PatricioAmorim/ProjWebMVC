using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebVendasMVC.Models;
using WebVendasMVC.Models.ViewModels;
using WebVendasMVC.Services;

namespace WebVendasMVC.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedorServices _vendedorSevices;
        private readonly DepartmentService _departmentService;
        
        public VendedoresController(VendedorServices vendedorServices, DepartmentService departmentService)
        {
            _vendedorSevices = vendedorServices;
            _departmentService = departmentService;
        }



        public IActionResult Index()
        {
            var list = _vendedorSevices.FindAll();
            
            return View(list);
        }


        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();

            var viewModel = new VendedorFormViewModel { Departments = departments };
            
            return View(viewModel);

        }

        [HttpPost][ValidateAntiForgeryToken]
        public IActionResult Create(Vendedores vendedores)
        {

            _vendedorSevices.InsereVendedor(vendedores);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Remove(int? id)
        {
            if(id == null)
            {

                return NotFound();

            }

            var obj = _vendedorSevices.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost][ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            _vendedorSevices.Remover(id);

            return RedirectToAction(nameof(Index));
        }
    }

}
