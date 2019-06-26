using Microsoft.AspNetCore.Mvc.RazorPages;
using AnjoAzul.Util;
using AnjoAzul.Model;
namespace AnjoAzul.Pages.DashBoard
{
    public class ListaPacientesModel : PageModel
    {
        public void OnGet()
        {
            var user = HttpContext.Session.GetObject<UsuarioModel>("USUARIO");
            ViewData["Nome"] = user.Nome;
        }
    }
}