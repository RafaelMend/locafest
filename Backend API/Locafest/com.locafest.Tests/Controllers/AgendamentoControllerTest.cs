using com.locafest.API.Controllers;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Service.Services;
using com.locafest.Tests.Mocks;
using Moq;
using System;
using Xunit;

namespace com.locafest.Tests.Controllers
{
    public class AgendamentoControllerTest
    {
        private readonly Mock<IAgendamentoRepository> agendamentoRepositoryMock = AgendamentoRepositoryMock.Instancia().Mock();

        [Fact]
        public void Inserir_Sucesso()
        {
            var controller = CreateAgendamentoController();

            var result = controller.Inserir(ObterObjeto());

            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Inserir_Falha()
        {
            var controller = CreateAgendamentoController();

            var result = controller.Inserir(new Agendamento());

            Assert.True(result.IsFaulted);
        }

        private AgendamentoController CreateAgendamentoController()
        {
            var agendamentoService = new AgendamentoService(agendamentoRepositoryMock.Object);

            return new AgendamentoController(agendamentoService);
        }

        public Agendamento ObterObjeto()
        {
            return new Agendamento
            {
                ClienteId = Guid.NewGuid(),
                DataDevolucao = DateTime.Now,
                DataRetirada = DateTime.Now,
                Id = Guid.NewGuid(),
                QuantidadeHoras = 10,
                ValorHora = 25,
                ValorFinal = 250,
                VeiculoId = Guid.NewGuid()
            };
        }
    }
}
