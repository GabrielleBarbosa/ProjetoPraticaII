﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace YourLife.Models
{
    public class Ranking
    {
        private string nickame;
        private int id;
        private int pontos;
        public Ranking()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }

        public string Nickname { get => nickame; set => nickame = value; }
        public int Pontos { get => pontos; set => pontos = value; }
        public int Id { get => id; set => id = value; }
    }
}