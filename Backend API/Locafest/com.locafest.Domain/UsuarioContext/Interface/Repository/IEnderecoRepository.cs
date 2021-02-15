using com.locafest.Domain.UsuarioContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.UsuarioContext.Interface.Repository
{
    public interface IEnderecoRepository
    {
        int Inserir(Endereco endereco);
        Endereco Obter(Guid enderecoId);
    }
}
