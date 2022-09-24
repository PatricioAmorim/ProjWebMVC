using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMVC.Models;
using Microsoft.EntityFrameworkCore;
using WebVendasMVC.Services.Exceptions;

namespace WebVendasMVC.Services
{
    public class VendedorServices 
    {
        

        private readonly WebVendasMVCContext _context;

        public VendedorServices(WebVendasMVCContext context)
        {
            _context = context;
        }


        public async Task<List<Vendedores>> FindAllAsinc()
        {
 
            return await _context.Vendedores.ToListAsync();

        }

        public async Task InsereVendedorAsync(Vendedores obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedores> FindByIdAsync(int id)
        {
            // Include utilizado como Join entre as tabelas das consultas
            return await _context.Vendedores.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }


        public async Task RemoverAsync(int id)
        {

            try
            {

            var Id = await _context.Vendedores.FindAsync(id);
            _context.Vendedores.Remove(Id);
            await _context.SaveChangesAsync();

            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdatesAsync(Vendedores obj)
        {

            bool hasany = await _context.Vendedores.AnyAsync(x => x.Id == obj.Id);
            if (!hasany)
            {
                throw new NotfoundException("Id not Found");
            }
            try
            {

                _context.Update(obj);
                await _context.SaveChangesAsync();

            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }


    }

}
