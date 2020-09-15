using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

namespace POO3D2_28_37.DAL
{
    public class tblLivroDAL
    {
        private MySqlConnection conexao;
        private string string_conexao = "Persist security info = false;" +
                                        "server=localhost;" +
                                        "database=BD_Livraria;" +
                                        "user=root ; pwd=;";

        public void conectar()
        {
            try
            {
                conexao = new MySqlConnection(string_conexao);
                conexao.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception("Problemas ao conectar com o banco de dados. Erro" + e.Message);
            }
        }

        public void executarComando(string sql)
        {
            try
            {
                conectar();
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                throw new Exception("Não foi possível executar a instrução banco de dados. Erro" + e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataTable executarConsulta(string sql)
        {
            try
            {
                conectar();
                DataTable dt = new DataTable();
                MySqlDataAdapter dados = new MySqlDataAdapter(sql, conexao);
                dados.Fill(dt);
                return dt;
            }
            catch (MySqlException e)
            {
                throw new Exception("Não foi possível selecionar os registros no banco de dados. Erro" + e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}