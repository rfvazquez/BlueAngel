using MySql.Data.MySqlClient;
using System;

namespace AnjoAzul.DataBase.MySql
{
    public class Connection
    {
        private MySqlConnection GetMySqlConnection()
        {
            var server = "remotemysql.com";
            var database = "2YDm8vDrQP";
            var login = "2YDm8vDrQP";
            var senha = "taFOuB6f27";



            var mySqlConnection = new MySqlConnection($"Persist Security Info=False;" +
                                                      $"server={server};" +
                                                      $"database={database};" +
                                                      $"uid={login};" +
                                                      $"server={server};" +
                                                      $"database={database};" +
                                                      $"uid={login};" +
                                                      $"pwd={senha}");
            try
            {
                mySqlConnection.Open();
            }
            catch (Exception)
            {
                mySqlConnection = null;
            }

            return mySqlConnection;
        }


        public DataBaseModel ExecuteNonQuery(string query)
        {
            var ret = new DataBaseModel();
            var conn = GetMySqlConnection();
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        var mySqlCommand = new MySqlCommand(query, conn);
                        mySqlCommand.ExecuteNonQuery();
                        ret.Sucesso = true;
                        conn.Clone();
                    }
                    catch (Exception ex)
                    {
                        ret.Sucesso = false;
                        ret.MensagemErro = $"Erro: {ex.Message}";
                    }
                }
                else
                {
                    ret.Sucesso = false;
                    ret.MensagemErro = "Erro ao Abrir a Connexão com banco de dados!";
                }
            }
            else
            {
                ret.Sucesso = false;
                ret.MensagemErro = "Erro ao Abrir a Connexão com banco de dados!";
            }
            return ret;
        }


        public DataBaseModel ExecuteMySqlQuery(string query)
        {
            var ret = new DataBaseModel();
            MySqlDataAdapter mAdapter = null;
            var conn = GetMySqlConnection();
            if (conn != null)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        mAdapter = new MySqlDataAdapter(query, conn);
                        ret.Sucesso = true;
                        ret.Retorno = mAdapter;
                        conn.Clone();
                    }
                    catch (Exception ex)
                    {
                        ret.Sucesso = false;
                        ret.MensagemErro = $"Erro: {ex.Message}";
                    }
                }
                else
                {
                    ret.Sucesso = false;
                    ret.MensagemErro = "Erro ao Abrir a Connexão com banco de dados!";
                }
            }
            else
            {
                ret.Sucesso = false;
                ret.MensagemErro = "Erro ao Abrir a Connexão com banco de dados!";
            }
            return ret;
        }
    }
}
