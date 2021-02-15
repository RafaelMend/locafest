using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Tests.Base;
using System;

namespace com.locafest.Tests.Mocks
{
    internal class MarcaRepositoryMock : MockBase<IMarcaRepository, MarcaRepositoryMock>
    {
        public MarcaRepositoryMock Inserir(Marca marca)
        {
            mock.Setup(mock => mock.Inserir(marca));
            return this;
        }
    }
}
