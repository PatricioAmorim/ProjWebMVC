using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMVC.Models;



namespace WebVendasMVC.Services
{
    public class VendasService
    {
        private readonly WebVendasMVCContext _context;

        public VendasService(WebVendasMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Vendas>> FindByDateAsync(DateTime? IniDate, DateTime? FimDate)
        {

            var result = from obj in _context.Vendas select obj;
            if (IniDate.HasValue)
            {
                result = result.Where(x => x.Data_Venda >= IniDate.Value );
            }
            if (FimDate.HasValue)
            {
                result = result.Where(x => x.Data_Venda <= FimDate.Value);
            }

            return await result
                    .Include(x => x.Vendedores)
                    .Include(x => x.Vendedores.Department)
                    .OrderByDescending(x => x.Data_Venda)
                    .ToListAsync();
        }


    }

}
