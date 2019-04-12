using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Ranking
/// </summary>
public class Ranking
{
    private string nickame;
    private int pontos;
    public Ranking()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }

    public string Nickame { get => nickame; set => nickame = value; }
    public int Pontos { get => pontos; set => pontos = value; }
}