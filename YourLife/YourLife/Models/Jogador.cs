﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourLife.Models
{
    public class Jogador
    {
        private int id;
        private string nickname;
        private int idade;
        private char sexo;
        private int pontosSaude;
        private int pontosInteligencia;
        private int pontosRelacionamento;
        private int pontosFelicidade;
        private double dinheiro;
        private char parceiro;
        private int codEmprego;
        private string senha;

        public Jogador(string nickname, string senha, char sexo, int idade, int pontosSaude, int PontosInteligencia, int pontosFelicidade, int PontosRelacionamento, double dinheiro, char parceiro)
        {
            Nickname = nickname;
            Senha = senha;
            Sexo = sexo;
            Idade = 0;
            PontosSaude = 1000;
            Random rm = new Random();
            PontosInteligencia = rm.Next(0, 450);
            PontosFelicidade = 500;
            PontosRelacionamento = 0;
            Dinheiro = 0;
            Parceiro = 'S';
        }

        public Jogador() { }

        public string Nickname { get => nickname; set => nickname = value; }
        public int Idade { get => idade; set => idade = value; }
        public char Sexo { get => sexo; set => sexo = value; }
        public int PontosSaude { get => pontosSaude; set => pontosSaude = value; }
        public int PontosInteligencia { get => pontosInteligencia; set => pontosInteligencia = value; }
        public int PontosRelacionamento { get => pontosRelacionamento; set => pontosRelacionamento = value; }
        public int PontosFelicidade { get => pontosFelicidade; set => pontosFelicidade = value; }
        public double Dinheiro { get => dinheiro; set => dinheiro = value; }
        public char Parceiro { get => parceiro; set => parceiro = value; }
        public int CodEmprego { get => codEmprego; set => codEmprego = value; }
        public string Senha { get => senha; set => senha = value; }
        public int Id { get => id; set => id = value; }
    }
}