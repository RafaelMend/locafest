using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.UsuarioContext.Entities
{
    public class Endereco : BaseEntity
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
