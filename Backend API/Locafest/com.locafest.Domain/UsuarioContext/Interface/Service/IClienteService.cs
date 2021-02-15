using com.locafest.Domain.UsuarioContext.Entities;
using System;

namespace com.locafest.Domain.UsuarioContext.Interface.Service
{
    public interface IClienteService
    {
        Result Inserir(Cliente cliente);
        Cliente Obter(Guid clienteId);
    }
}
