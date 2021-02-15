using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Tests.Base;
using System;

namespace com.locafest.Tests.Mocks
{
    internal class ClienteRepositoryMock : MockBase<IClienteRepository, ClienteRepositoryMock>
    {
        public ClienteRepositoryMock Obter(Guid clienteId)
        {
            mock.Setup(mock => mock.Obter(clienteId));
            return this;
        }

        public ClienteRepositoryMock Obter(string cpf, string senha)
        {
            mock.Setup(mock => mock.Obter(cpf, senha));
            return this;
        }

        public ClienteRepositoryMock Inserir(Cliente cliente)
        {
            mock.Setup(mock => mock.Inserir(cliente));
            return this;
        }
    }
}
