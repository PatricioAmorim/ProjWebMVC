﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMVC.Models;
using Microsoft.EntityFrameworkCore;

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

        public void InsereVendedor(Vendedores obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedores FindById(int id)
        {
            // Include utilizado como Join entre as tabelas das consultas
            return _context.Vendedores.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }


        public void Remover(int id)
        {
            var Id = _context.Vendedores.Find(id);
            _context.Vendedores.Remove(Id);
            _context.SaveChanges();

        }
    }

}
