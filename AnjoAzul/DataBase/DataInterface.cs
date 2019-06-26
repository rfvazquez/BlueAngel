using AnjoAzul.DataBase.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnjoAzul.DataBase
{
    public class DataInterface
    {
        public DataBaseModel GetLogin(string login)
        {
            var query = new Query();
            return query.LoginUsuario(login);
        }
    }
}
