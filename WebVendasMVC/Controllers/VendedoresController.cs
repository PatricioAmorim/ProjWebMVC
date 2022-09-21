using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebVendasMVC.Models;
using WebVendasMVC.Models.ViewModels;
using WebVendasMVC.Services;
using WebVendasMVC.Services.Exceptions;

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

        public IActionResult Detalhe(int? id)
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

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _vendedorSevices.FindById(id.Value);
            if (obj == null )
            {
                return NotFound();
            }

            List<Department> departments = _departmentService.FindAll();
            VendedorFormViewModel viewModel = new VendedorFormViewModel() { Vendedores = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedores vendedorer)
        {
            if(id != vendedorer.Id)
            {
                return BadRequest();
            }
            try
            {

                _vendedorSevices.Updates(vendedorer);
                return RedirectToAction(nameof(Index));
            }
            catch(NotfoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }



        }

    }

}
