using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YourLife.Models
{
    public class Jogador
    {
        //    private int id;
        //    private string nickname;
        //    private int idade;
        //    private char sexo;
        //    private int pontosSaude;
        //    private int pontosInteligencia;
        //    private int pontosRelacionamento;
        //    private int pontosFelicidade;
        //    private double dinheiro;
        //    private char parceiro;
        //    private int codEmprego;
        //    private string senha;

        //    public Jogador(string nickname, string senha, char sexo, int idade, int pontosSaude, int PontosInteligencia, int pontosFelicidade, int PontosRelacionamento, double dinheiro, char parceiro)
        //    {
        //        Nickname = nickname;
        //        Senha = senha;
        //        Sexo = sexo;
        //        Idade = 0;
        //        PontosSaude = 1000;
        //        Random rm = new Random();
        //        PontosInteligencia = rm.Next(0, 450);
        //        PontosFelicidade = 500;
        //        PontosRelacionamento = 0;
        //        Dinheiro = 0;
        //        Parceiro = 'S';
        //    }

        //    public Jogador() { }


        [Required, StringLength(30)]
        public string Nickname { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public int PontosSaude { get; set; }
        public int PontosInteligencia { get; set; }
        public int PontosRelacionamento { get; set; }
        public int PontosFelicidade { get; set; }
        public double Dinheiro { get; set; }
        public char Parceiro { get; set; }
        public int CodEmprego { get; set; }
        [Required, StringLength(20)]
        public string Senha { get; set; }
        public int Id { get; set; }
    }
}