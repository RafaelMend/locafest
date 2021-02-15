using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using com.locafest.Domain.LocacaoContext.Model;
using Serilog;
using System;

namespace com.locafest.Service.Services
{
    public class SimulacaoService : ISimulacaoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public SimulacaoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public SimulacaoModel ObterSimulacao(Guid veiculoId, DateTime dataRetirada, DateTime dataDevolucao)
        {                  
            try
            {
                var veiculo = _veiculoRepository.Obter(veiculoId);
                return new SimulacaoModel(veiculoId, dataRetirada, dataDevolucao, veiculo.ValorHora);
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                return null;
            }            
        }
    }
}
