using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebVendasMVC.Models;

namespace WebVendasMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();

            list.Add(new Department { Id = 1, Nome = "Eletronicos" });
            list.Add(new Department { Id = 2, Nome = "Artigos infantis" });

            return View(list);
        }
    }
}
