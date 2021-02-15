using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Tests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Tests.Mocks
{
    internal class VistoriaRepositoryMock : MockBase<IVistoriaRepository, VistoriaRepositoryMock>
    {
        public VistoriaRepositoryMock Obter(Guid vistoriaId)
        {
            mock.Setup(mock => mock.Obter(vistoriaId));
            return this;
        }

        public VistoriaRepositoryMock Inserir(Vistoria objeto)
        {
            mock.Setup(mock => mock.Inserir(objeto));
            return this;
        }
    }
}
