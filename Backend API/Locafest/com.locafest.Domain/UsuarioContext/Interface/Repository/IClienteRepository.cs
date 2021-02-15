using com.locafest.Domain.UsuarioContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.UsuarioContext.Interface.Repository
{
    public interface IClienteRepository
    {
        int Inserir(Cliente cliente);
        Cliente Obter(string matricula, string senha);
        Cliente Obter(Guid clienteId);
    }
}
