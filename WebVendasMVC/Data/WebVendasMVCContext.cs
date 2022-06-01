using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebVendasMVC.Models;

namespace WebVendasMVC.Data
{
    public class WebVendasMVCContext : DbContext
    {
        public WebVendasMVCContext (DbContextOptions<WebVendasMVCContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
        public DbSet<Venderores> Venderores { get; set; }
    }
}
