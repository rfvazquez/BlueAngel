using AnjoAzul.Model;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace AnjoAzul.DataBase.MySql
{
    public class Query
    {
        #region usuario
        public DataBaseModel CriaUsuario(UsuarioModel usuario)
        {
            var ret = new DataBaseModel();
            var conn = new Connection();
            try
            {
                var query = $"insert into tb_usuario(usu_Nome, usu_Sobrenome, usu_Email, usu_Senha) " +
                    $"values({usuario.Nome},{usuario.SobreNome}, {usuario.EMail}, {usuario.Senha}) ";
                ret = conn.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                ret.Sucesso = false;
                ret.MensagemErro = ex.Message;
            }
            return ret;
        }


        public DataBaseModel AlteraUsuario(UsuarioModel usuario)
        {
            var ret = new DataBaseModel();
            var conn = new Connection();
            try
            {
                var query = $"update tb_usuario " +
                    $"set usu_nome = '{usuario.Nome}'," +
                    $" usu_Sobrenome = '{usuario.SobreNome}'," +
                    $" usu_Email = '{usuario.EMail}'," +
                    $" usu_Senha = '{usuario.Senha}'," +
                    $" usu_Valido = {usuario.Valido} " +
                    $" where usu_id= {usuario.Id}";

                ret = conn.ExecuteNonQuery(query);

            }catch(Exception ex)
            {
                ret.Sucesso = false;
                ret.MensagemErro = ex.Message;
            }
            return ret;
        }


        public DataBaseModel LoginUsuario(string eMail)
        {
            var ret = new DataBaseModel();
            var conn = new Connection();
            var dataSet = new DataSet();
            try
            {
                var query = $"select * from tb_usuario where usu_email = '{eMail}'";
                var connRet = conn.ExecuteMySqlQuery(query);
                if (!connRet.Sucesso)
                {
                    ret = connRet;
                }
                else
                {
                    var retornoCompilado = (MySqlDataAdapter)connRet.Retorno;
                    retornoCompilado.Fill(dataSet, "usuarios");
                    var usuarioModel = new UsuarioModel()
                    {
                        Id = Convert.ToInt32(dataSet.Tables["usuarios"].Rows[0]["usu_Id"].ToString()),
                        DataCriacao = Convert.ToDateTime(dataSet.Tables["usuarios"].Rows[0]["usu_DataCriacao"].ToString()),
                        EMail = dataSet.Tables["usuarios"].Rows[0]["usu_Email"].ToString(),
                        Nome = dataSet.Tables["usuarios"].Rows[0]["usu_Nome"].ToString(),
                        Senha = dataSet.Tables["usuarios"].Rows[0]["usu_Senha"].ToString(),
                        SobreNome = dataSet.Tables["usuarios"].Rows[0]["usu_Sobrenome"].ToString(),
                        Valido = Convert.ToBoolean(dataSet.Tables["usuarios"].Rows[0]["usu_Valido"].ToString())
                    };
                    ret.Sucesso = true;
                    ret.Retorno = usuarioModel;
                }
            }
            catch (Exception ex)
            {
                ret.Sucesso = false;
                ret.MensagemErro = ex.Message;
            }

            return ret;
        }
        #endregion
    }
}
