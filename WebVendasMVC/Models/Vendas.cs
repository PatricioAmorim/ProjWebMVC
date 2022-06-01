using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebVendasMVC.Models.Enums;

namespace WebVendasMVC.Models
{
    public class Vendas
    {

        public int ID{ get; set; }
        public DateTime Data_Venda { get; set; }
        public double ValVendas   { get; set; }
        public StatusVendas Status { get; set; }
        public Venderores Venderores { get; set; }

        public Vendas() { }

        public Vendas(int iD, DateTime data_Venda, double valvendas, StatusVendas status, Venderores venderores)
        {
            ID = iD;
            Data_Venda = data_Venda;
            ValVendas = valvendas;
            Status = status;
            Venderores = venderores;
        }

    }

}
