using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// tabela com as características e informações principais da classe Jogador, que remete ao Usuário do jogo e seu personagem, contendo todas as 
/// informações necessárias para se salvar seu progresso
/// </summary>

public class Jogador
{
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

    public Jogador()
    {

    }

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
}