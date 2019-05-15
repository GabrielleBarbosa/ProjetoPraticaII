using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YourLife.Models
{
    public class Personagem
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Senha { get; set; }
        [Required, StringLength(30)]
        public string nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public int PontosSaude { get; set; }
        public int PontosInteligencia { get; set; }
        public int PontosRelacionamento { get; set; }
        public int PontosFelicidade { get; set; }
        public decimal Dinheiro { get; set; }
        public char Parceiro { get; set; }
        public int CodEmprego { get; set; }
    }
}