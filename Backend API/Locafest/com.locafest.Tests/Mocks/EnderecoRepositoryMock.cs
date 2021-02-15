using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Tests.Base;
using System;

namespace com.locafest.Tests.Mocks
{
    internal class EnderecoRepositoryMock : MockBase<IEnderecoRepository, EnderecoRepositoryMock>
    {
        public EnderecoRepositoryMock Obter(Guid enderecoId)
        {
            mock.Setup(mock => mock.Obter(enderecoId));
            return this;
        }

        public EnderecoRepositoryMock Inserir(Endereco endereco)
        {
            mock.Setup(mock => mock.Inserir(endereco));
            return this;
        }
    }
}
