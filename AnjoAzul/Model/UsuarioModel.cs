using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnjoAzul.Model
{
    public class UsuarioModel
    {
        public int Id {set;get;}
        public string Nome { set; get; }
        public string SobreNome { set; get; }
        public string EMail { set; get; }
        public string Senha { set; get; }
        public bool Valido { set; get; }
        public DateTime DataCriacao { set; get; }
    }
}
