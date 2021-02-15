using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using com.locafest.Tests.Base;
using System;

namespace com.locafest.Tests.Mocks
{
    internal class ClienteServiceMock : MockBase<IClienteService, ClienteServiceMock>
    {
        public ClienteServiceMock Obter(Guid clienteId)
        {
            mock.Setup(mock => mock.Obter(clienteId));
            return this;
        }

        public ClienteServiceMock Inserir(Cliente cliente)
        {
            mock.Setup(mock => mock.Inserir(cliente));
            return this;
        }
    }
}
