using AnjoAzul.DataBase.MySql;
using AnjoAzul.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnjoAzul.DataBase
{
    public class DataInterface
    {
        #region Usuario
        public DataBaseModel GetLogin(string login)
        {
            var query = new Query();
            return query.LoginUsuario(login);
        }

        public DataBaseModel UpdateUsuario(UsuarioModel usuario)
        {
            var query = new Query();
            return query.AlteraUsuario(usuario);
        }
        public DataBaseModel InsereUsuario(UsuarioModel usuario)
        {
            var query = new Query();
            return query.CriaUsuario(usuario);
        }
        #endregion

    }
}
