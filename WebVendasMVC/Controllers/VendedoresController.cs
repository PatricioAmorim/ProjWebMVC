using System;
using System.Collections.Generic;
using System.Diagnostics;
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

                return RedirectToAction(nameof(Error), new {message = "Id Nulo" });

            }

            var obj = _vendedorSevices.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Não Encontrado" });
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
                return RedirectToAction(nameof(Error), new { message = "Id não informado" });
            }

            var obj = _vendedorSevices.FindById(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" }); ;
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não nformado" });
            }

            var obj = _vendedorSevices.FindById(id.Value);
            if (obj == null )
            {
                return RedirectToAction(nameof(Error), new { message = $"Id {0} não encontrado", id.Value });
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
                return RedirectToAction(nameof(Error), new { message = $"Id {0} nao correspondente como vendedor {1}", id, vendedorer.Name});
            }
            try
            {

                _vendedorSevices.Updates(vendedorer);
                return RedirectToAction(nameof(Index));
            }
            catch(NotfoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {

                Message = message,
                // Utilizado para pegar o id da requisição
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };


            return View(viewModel);
        }

    }

}
