﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVendasMVC.Models
{
    public class Vendedores
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50 , MinimumLength = 3, ErrorMessage ="{0} dever ter entre {2} e {1} caracteres")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Data aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}")]
        public DateTime Dt_aniversario { get; set; }

        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        public double SalarioBase { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Vendas> listaVendas { get; set; } = new List<Vendas>();

        public Vendedores() { }

        public Vendedores(int id, string name, string email, DateTime dt_aniversario, double salarioBase, Department department)
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
