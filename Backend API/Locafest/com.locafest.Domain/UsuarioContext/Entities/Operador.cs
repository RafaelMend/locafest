using com.locafest.Domain.UsuarioContext.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.UsuarioContext.Entities
{
    public class Operador : BaseEntity
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } 
        public int PerfilId { get { return (int) PerfilEnum.Operador; } }
    }
}
