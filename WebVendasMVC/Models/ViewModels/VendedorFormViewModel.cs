using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMVC.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedores Vendedores { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
