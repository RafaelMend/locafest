using com.locafest.API.Controllers;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using com.locafest.Service.Services;
using com.locafest.Tests.Mocks;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace com.locafest.Tests.Controllers
{
    public class ContratoControllerTest
    {
        private readonly Mock<IAgendamentoService> agendamentoServiceMock = AgendamentoServiceMock.Instancia().Mock();
        private readonly Mock<IVeiculoService> veiculoServiceMock = VeiculoServiceMock.Instancia().Mock();
        private readonly Mock<IClienteService> clienteServiceMock = ClienteServiceMock.Instancia().Mock();
        private readonly Mock<IContratoRepository> contratoRepositoryMock = ContratoRepositoryMock.Instancia().Mock();
        private readonly IConverter _converter;

        [Fact]
        public void Inserir_Falha()
        {
            var controller = CreateContratoController();

            var result = controller.CreatePDF(Guid.NewGuid());

            Assert.IsNotType<FileContentResult>(result);
        }

        private ContratoController CreateContratoController()
        {
            var contratoService = new ContratoService(agendamentoServiceMock.Object, veiculoServiceMock.Object,
                clienteServiceMock.Object, contratoRepositoryMock.Object);

            return new ContratoController(_converter, contratoService);
        }
    }
}
