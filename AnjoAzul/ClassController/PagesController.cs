using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnjoAzul.DataBase;
using AnjoAzul.Model;
using Microsoft.AspNetCore.Mvc;
using AnjoAzul.Util;

namespace AnjoAzul.ClassController
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public string Login(string login, string senha)
        {
            var ret = String.Empty;
            var dataInterface = new DataInterface();
            var retLogin = dataInterface.GetLogin(login);
            if (retLogin.Sucesso)
            {
                var user = (UsuarioModel)retLogin.Retorno;
                if (user.Senha != senha)
                {
                    ret = "Erro: Senha Inválida";
                }
                else
                {
                    HttpContext.Session.SetObject("USUARIO", user);
                    ViewData["Nome"] = user.Nome;
                    ret = base.Url.Action("ListaPacientes", "DashBoard"); ;
                }
            }
            else
            {
                if (retLogin.MensagemErro.Contains("row"))
                {
                    ret = "Erro: Usuário não encontrado!";
                }
                else
                {
                    ret = $"Erro: {retLogin.MensagemErro}";
                }

            }

            return ret;
        }

        [HttpPost]
        public string EsqueciSenha(string email)
        {
            var ret = String.Empty;
            var dataInterface = new DataInterface();
            var retLogin = dataInterface.GetLogin(email);
            if (retLogin.Sucesso)
            {
                var user = (UsuarioModel)retLogin.Retorno;
                var corpoEmail = $"Olá {user.Nome}! <br/>" +
                                "<p>Se você está recebendo este E-Mail é porque solicitou sua senha no sistema Anjo Azul <br/><br/>" +
                                $"Seu usuário para acesso é: {user.EMail}<br/>" +
                                $"Sua senha para acesso é: {user.Senha}<br/>" +
                                "<br/>" +
                                "Att.<br/>Sistema Anjo Azul!";
                return EmailUtils.SendMail("Recuperação de Senha - Anjo Azul", corpoEmail, email);
            }
            else
            {
                return "Usuário não encontrado em nossa base de dados";
            }
        }

        [HttpPost]
        public string AlterarSenha(string novaSenha, string senhaAntiga)
        {
            var user = HttpContext.Session.GetObject<UsuarioModel>("USUARIO");
            var dataInterface = new DataInterface();
            if (senhaAntiga != user.Senha)
            {
                return "Erro: Senha antiga incorreta!";
            }
            user.Senha = novaSenha;
            var alteraSenha = dataInterface.UpdateUsuario(user);
            if (alteraSenha.Sucesso)
            {
                return "Senha alterada com sucesso!";
            }
            else
            {
                return $"Erro: {alteraSenha.MensagemErro}";
            }
        }

        [HttpPost]
        public string Logout()
        {
            HttpContext.Session.Clear();
            ViewData["Nome"] = "";
            return "/Index";
        }

    }
}