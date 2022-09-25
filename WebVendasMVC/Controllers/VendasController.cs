using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebVendasMVC.Models;
using WebVendasMVC.Services;

namespace WebVendasMVC.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendasService _VendasService;

        public VendasController(VendasService vendasService)
        {
            _VendasService = vendasService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? IniDate, DateTime? FimDate)
        {
            var result = await _VendasService.FindByDateAsync(IniDate,FimDate);
            return View(result);
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }

    }
}
