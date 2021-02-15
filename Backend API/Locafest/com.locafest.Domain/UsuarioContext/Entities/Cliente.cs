using com.locafest.Domain.UsuarioContext.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.UsuarioContext.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime Aniversario { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid EnderecoId { get; set; }
        public Usuario Usuario { get; set; }
        public Endereco Endereco { get; set; }
        public int PerfilId { get { return (int)PerfilEnum.Cliente; } }
    }
}
