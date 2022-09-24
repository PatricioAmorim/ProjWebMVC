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



        public async Task<IActionResult> Index()
        {
            var list = await _vendedorSevices.FindAllAsinc();
            
            return View(list);
        }


        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();

            var viewModel = new VendedorFormViewModel { Departments = departments };
            
            return View(viewModel);

        }

        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedores vendedores)
        {
            if (!ModelState.IsValid) // validação caso o Js esteja desabilitado, valida antes de enviar ao Servidor.
            {
                var departments = await _departmentService.FindAllAsync();
                var ViewModel = new VendedorFormViewModel{Vendedores = vendedores, Departments = departments};
                return View(ViewModel);
            }
            await _vendedorSevices.InsereVendedorAsync(vendedores);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Remove(int? id)
        {
            if(id == null)
            {

                return RedirectToAction(nameof(Error), new {message = "Id Nulo" });

            }

            var obj = await _vendedorSevices.FindByIdAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Não Encontrado" });
            }

            return View(obj);
        }

        [HttpPost][ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {

                await _vendedorSevices.RemoverAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Detalhe(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não informado" });
            }

            var obj = await _vendedorSevices.FindByIdAsync(id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não nformado" });
            }

            var obj = await _vendedorSevices.FindByIdAsync(id.Value);
            if (obj == null )
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado"});
            }

            List<Department> departments = await _departmentService.FindAllAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel() { Vendedores = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Vendedores vendedorer)
        {
            if (!ModelState.IsValid) // validação caso o Js esteja desabilitado, valida antes de enviar ao Servidor.
            {
                var departments = await _departmentService.FindAllAsync();
                var ViewModel = new VendedorFormViewModel { Vendedores = vendedorer, Departments = departments }; // 
                return View(ViewModel);
            }

            if (id != vendedorer.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id nao correspondente com o vendedor"});
            }
            try
            {

                await _vendedorSevices.UpdatesAsync(vendedorer);
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


        // Metodo para pegar erro para a interface ViewModel
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
