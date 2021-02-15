using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using Serilog;
using System;

namespace com.locafest.Service.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public Agendamento Obter(Guid agendamentoId)
        {
            return _agendamentoRepository.Obter(agendamentoId);
        }

        public Result Inserir(Agendamento agendamento)
        {
            try
            {
                int retorno = _agendamentoRepository.Inserir(agendamento);
                if (retorno == 1)
                    return Result.Ok();
                else
                {
                    agendamento.AddNotification("Erros", "Ocorreu algum erro na transação do banco de dados.");
                    return Result.Error(agendamento.Notifications);
                }
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                agendamento.AddNotification("Erros", e.Message);
                return Result.Error(agendamento.Notifications);
            }
            
        }
    }
}
