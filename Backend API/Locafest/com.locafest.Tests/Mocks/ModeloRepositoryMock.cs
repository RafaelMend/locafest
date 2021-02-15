using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Tests.Base;
using System;

namespace com.locafest.Tests.Mocks
{
    internal class ModeloRepositoryMock : MockBase<IModeloRepository, ModeloRepositoryMock>
    {
        public ModeloRepositoryMock Inserir(Modelo modelo)
        {
            mock.Setup(mock => mock.Inserir(modelo));
            return this;
        }
    }
}
