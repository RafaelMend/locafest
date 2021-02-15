using com.locafest.Domain.LocacaoContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Interface.Repository
{
    public interface IAgendamentoRepository
    {
        int Inserir(Agendamento agendamento);
        Agendamento Obter(Guid agendamentoId);
    }
}
