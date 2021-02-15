using com.locafest.API.Controllers;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Service.Services;
using com.locafest.Tests.Mocks;
using Moq;
using System;
using Xunit;

namespace com.locafest.Tests.Controllers
{
    public class VistoriaControllerTest
    {
        private readonly Mock<IVistoriaRepository> vistoriaRepositoryMock = VistoriaRepositoryMock.Instancia().Mock();

        [Fact]
        public void Inserir_Sucesso()
        {
            var controller = CreateVistoriaController();

            var result = controller.Inserir(ObterObjeto());

            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Inserir_Falha()
        {
            var controller = CreateVistoriaController();

            var result = controller.Inserir(new Vistoria());

            Assert.True(result.IsFaulted);
        }

        private VistoriaController CreateVistoriaController()
        {
            var vistoriaService = new VistoriaService(vistoriaRepositoryMock.Object);

            return new VistoriaController(vistoriaService);
        }

        public Vistoria ObterObjeto()
        {
            return new Vistoria
            {
                Id = Guid.NewGuid(),
                ContratoId = Guid.NewGuid(),
                IndiceAmassados = false,
                IndiceArranhoes = true,
                IndiceCarroLimpo = false,
                IndiceTanqueCheio = true,
                PercentualOcorrencia = 30            
            };
        }
    }
}
