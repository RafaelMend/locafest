using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Tests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Tests.Mocks
{
    internal class AgendamentoRepositoryMock : MockBase<IAgendamentoRepository, AgendamentoRepositoryMock>
    {
        public AgendamentoRepositoryMock Obter(Guid agendamentoId)
        {
            mock.Setup(mock => mock.Obter(agendamentoId));
            return this;
        }

        public AgendamentoRepositoryMock Inserir(Agendamento objeto)
        {
            mock.Setup(mock => mock.Inserir(objeto));
            return this;
        }
    }
}
