using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnjoAzul.DataBase
{
    public class DataBaseModel
    {
        public bool Sucesso { set; get; }
        public string MensagemErro { set; get; }
        public object Retorno { set; get; }
    }
}
