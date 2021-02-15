using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Tests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Tests.Mocks
{
    internal class VeiculoRepositoryMock : MockBase<IVeiculoRepository, VeiculoRepositoryMock>
    {
        public VeiculoRepositoryMock Obter(Guid veiculoId)
        {
            mock.Setup(mock => mock.Obter(veiculoId));
            return this;
        }

        public VeiculoRepositoryMock Inserir(Veiculo objeto)
        {
            mock.Setup(mock => mock.Inserir(objeto));
            return this;
        }
    }
}
