using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Tests.Base;
using System;

namespace com.locafest.Tests.Mocks
{
    internal class ContratoRepositoryMock : MockBase<IContratoRepository, ContratoRepositoryMock>
    {
        public ContratoRepositoryMock Inserir(Contrato contrato)
        {
            mock.Setup(mock => mock.Inserir(contrato));
            return this;
        }
    }
}
