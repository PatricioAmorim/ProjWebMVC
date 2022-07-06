using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMVC.Models;

namespace WebVendasMVC.Services
{
    public class DepartmentService
    {

        private readonly WebVendasMVCContext _context;

        public DepartmentService(WebVendasMVCContext context)
        {
            _context = context;
        }


        public List<Department> FindAll()
        {

            return _context.Department.OrderBy(x => x.Nome).ToList() ;

        }

    }


}
