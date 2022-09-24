using Microsoft.EntityFrameworkCore;
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

        /* Chamada de list forma Sincrona
        public List<Department> FindAll()
        {

            return _context.Department.OrderBy(x => x.Nome).ToList() ;

        }
        */
        // Chamada de list forma Asincrona
        public async Task<List<Department>> FindAllAsync()
        {

            return await _context.Department.OrderBy(x => x.Nome).ToListAsync();

        }

        
    }


}
