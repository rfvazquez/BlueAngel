using Microsoft.AspNetCore.Mvc;
using AnjoAzul.Model;
using AnjoAzul.DataBase;

namespace AnjoAzul.ClassController
{
    public class CadastroController : Controller
    {

        [HttpPost]
        public string RealizaCadastro(string confSenha, string nome, string sobrenome, string senha, string email)
        {
            var dataInterface = new DataInterface();
            string retorno = string.Empty;
            //Pega informações do usuário
            var user = new UsuarioModel()
            {
                EMail = email, 
                Nome = nome, 
                Senha = confSenha,
                SobreNome = sobrenome, 
                
            };

            var retConsultaEmail = dataInterface.GetLogin(email);
            //Verifica se email ja foi utilizado anteriormente
            if (!retConsultaEmail.Sucesso)
            {
                //Realiza cadastro do usuário
                var retInsercao = dataInterface.InsereUsuario(user);
                if (retInsercao.Sucesso)
                {
                    retorno = "Cadastro Realizado com Sucesso";
                }
                else
                {
                    retorno = retInsercao.MensagemErro;
                }
            }
            else
            {
                retorno = "Erro: E-mail já cadastrado!";
            }
            
            return retorno;
        }
    }
}