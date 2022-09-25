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
            if (!IniDate.HasValue)
            {
                IniDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!IniDate.HasValue)
            {
                FimDate = DateTime.Now;
            }

            ViewData["IniDate"] = IniDate.Value.ToString("yyyy-MM-dd");
            ViewData["FimDate"] = IniDate.Value.ToString("yyyy-MM-dd");

            var result = await _VendasService.FindByDateAsync(IniDate,FimDate);
            return View(result);
        }

        public async Task<IActionResult> BuscaAgrupada(DateTime? IniDate, DateTime? FimDate)
        {
            if (!IniDate.HasValue)
            {
                IniDate = new DateTime(DateTime.Today.Year , 1, 1);
            }
            if (!IniDate.HasValue)
            {
                FimDate = DateTime.Now;
            }

            ViewData["IniDate"] = IniDate.Value.ToString("yyyy-MM-dd");
            ViewData["FimDate"] = IniDate.Value.ToString("yyyy-MM-dd");

            var result = await _VendasService.FindByDateGroupingAsync(IniDate, FimDate);
            return View(result);
        }

    }
}
