using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Tests.Base;
using System;

namespace com.locafest.Tests.Mocks
{
    internal class OperadorRepositoryMock : MockBase<IOperadorRepository, OperadorRepositoryMock>
    {
        public OperadorRepositoryMock Inserir(Operador operador)
        {
            mock.Setup(mock => mock.Inserir(operador));
            return this;
        }

        public OperadorRepositoryMock Obter(string matricula, string senha)
        {
            mock.Setup(mock => mock.Obter(matricula, senha));
            return this;
        }
    }
}
