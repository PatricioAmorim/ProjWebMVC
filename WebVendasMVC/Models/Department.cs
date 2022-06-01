using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMVC.Models
{
    public class Department
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Venderores> venderores { get; set; } = new List<Venderores>();


        public Department()
        {

        }

        public Department(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddVendedor(Venderores venderor)
        {
            venderores.Add(venderor);
        }

        public double TotalVendas(DateTime dt_inicio, DateTime dt_fim)
        {

            return venderores.Sum(vendedor => vendedor.TotalVendas(dt_inicio, dt_fim));

        }
    }
}
