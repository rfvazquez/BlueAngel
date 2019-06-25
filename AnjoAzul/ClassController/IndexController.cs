using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnjoAzul.ClassController
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        public string Login (string login, string senha)
        {
            var teste = "aqui";
            return teste;
        }
    }
}