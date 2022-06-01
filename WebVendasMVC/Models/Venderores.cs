using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMVC.Models
{
    public class Venderores
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Dt_aniversario { get; set; }
        public double SalarioBase { get; set; }
        public Department Department { get; set; }

        public ICollection<Vendas> listaVendas { get; set; } = new List<Vendas>();


        public Venderores()
        {

        }

        public Venderores(int id, string name, string email, DateTime dt_aniversario, double salarioBase, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Dt_aniversario = dt_aniversario;
            SalarioBase = salarioBase;
            Department = department;
        }

        public void AddVendas(Vendas venda)
        {
            listaVendas.Add(venda);
        }

        public void RemoveVenda(Vendas venda)
        {
            listaVendas.Remove(venda);
        }

        public double TotalVendas(DateTime DataInicio, DateTime DataFim)
        {
            return listaVendas.Where(vd => vd.Data_Venda >= DataInicio && vd.Data_Venda <= DataFim).Sum(vd => vd.ValVendas);
        }
    }
}
