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
    public class ModeloControllerTest
    {
        private readonly Mock<IModeloRepository> modeloRepositoryMock = ModeloRepositoryMock.Instancia().Mock();

        [Fact]
        public void Inserir_Sucesso()
        {
            var controller = CreateModeloController();

            var result = controller.Inserir(ObterObjeto());

            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Inserir_Falha()
        {
            var controller = CreateModeloController();

            var result = controller.Inserir(new Modelo());

            Assert.True(result.IsFaulted);
        }

        private ModeloController CreateModeloController()
        {
            var modeloService = new ModeloService(modeloRepositoryMock.Object);

            return new ModeloController(modeloService);
        }

        public Modelo ObterObjeto()
        {
            return new Modelo
            {
                Id = Guid.NewGuid(),
                Descricao = "teste"
            };
        }
    }
}
