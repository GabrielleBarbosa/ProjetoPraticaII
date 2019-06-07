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
        public int CodUsuario { get; set; }
        [Required, StringLength(15)]
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public int PontosSaude { get; set; }
        public int PontosInteligencia { get; set; }
        public int PontosRelacionamento { get; set; }
        public int PontosFelicidade { get; set; }
        public decimal Dinheiro { get; set; }
        public int Parceiro { get; set; }
        public int CodEmprego { get; set; }
        public char CarteiraMotorista { get; set; }
        public int CodCursando { get; set; }
        public int AnosCursando { get; set; }
    }
}