using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data.SqlClient;
using YourLife.Models;

/// <summary>
/// Descrição resumida de RankingDAO
/// </summary>
public class RankingDAO
{
    private SqlConnection conexao;
    public RankingDAO()
    {
        conexao = new SqlConnection("Data Source=regulus.cotuca.unicamp.br;Initial Catalog=PR118200;User ID=PR118200;Password=f3l1p3l3o");
        conexao.Open();
    }

    public void Dispose()
    {
        conexao.Close();
    }

    internal IList<Ranking> ListarRanking()
    {
        try
        {
            var lista = new List<Ranking>();
            var sqlSelect = conexao.CreateCommand();

            sqlSelect.CommandText = "SELECT * FROM Ranking";

            var resultado = sqlSelect.ExecuteReader();

            while (resultado.Read())
            {
                Ranking rk = new Ranking();
                rk.Nickame = Convert.ToString(resultado["Nickname"]);
                rk.Pontos = Convert.ToInt32(resultado["pontos"]);
                lista.Add(rk);
            }
            resultado.Close();
            return lista;
        }
        catch (SqlException)
        {
            throw new SystemException("Ocorreu um erro ao listar o Ranking");
        }
    }
}