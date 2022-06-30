using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMVC.Models;

namespace WebVendasMVC.Services
{
    public class VendedorServices 
    {
        

        private readonly WebVendasMVCContext _context;

        public VendedorServices(WebVendasMVCContext context)
        {
            _context = context;
        }


        public List<Vendedores> FindAll()
        {
 
            return _context.Vendedores.ToList();

        }
    }
}
