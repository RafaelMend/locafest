using com.locafest.Domain.LocacaoContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Interface.Service
{
    public interface IAgendamentoService
    {
        Result Inserir(Agendamento agendamento);
        Agendamento Obter(Guid agendamentoId);
    }
}
