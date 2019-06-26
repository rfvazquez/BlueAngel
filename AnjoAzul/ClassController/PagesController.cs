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

    }
}