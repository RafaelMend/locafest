using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using com.locafest.Domain.LocacaoContext.Model;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using Serilog;
using System;

namespace com.locafest.Service.Services
{
    public class ContratoService : IContratoService
    {
        public readonly IAgendamentoService _agendamentoService;
        public readonly IVeiculoService _veiculoService;
        public readonly IClienteService _clienteService;
        public readonly IContratoRepository _contratoRepository;

        public ContratoService(IAgendamentoService agendamentoService, IVeiculoService veiculoService, 
            IClienteService clienteService, IContratoRepository contratoRepository)
        {
            _agendamentoService = agendamentoService;
            _veiculoService = veiculoService;
            _clienteService = clienteService;
            _contratoRepository = contratoRepository;
        }

        public ContratoPdfModel ObterContrato(Guid agendamentoId)
        {
            try
            {
                var agendamento = _agendamentoService.Obter(agendamentoId);
                var cliente = _clienteService.Obter(agendamento.ClienteId);
                var veiculo = _veiculoService.Obter(agendamento.VeiculoId);

                GravarContrato(agendamento);

                return new ContratoPdfModel
                {
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero,
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Endereco.Estado,
                    ModeloVeiculo = veiculo.Modelo.Descricao,
                    MarcaVeiculo = veiculo.Marca.Descricao,
                    AnoVeiculo = veiculo.Ano,
                    DataRetirada = agendamento.DataRetirada,
                    DataDevolucao = agendamento.DataDevolucao,
                    ValorFinal = agendamento.ValorFinal,
                    QuantidadeHoras = agendamento.QuantidadeHoras
                };
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                return null;
            }
        }

        private void GravarContrato(Agendamento agendamento)
        {
            Contrato contrato = new Contrato
            {
                AgendamentoId = agendamento.Id,
                DataContratacao = DateTime.Now,
                Id = Guid.NewGuid()
            };
            _contratoRepository.Inserir(contrato);
        }
    }
}
