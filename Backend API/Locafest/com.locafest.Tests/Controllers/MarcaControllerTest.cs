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
    public class MarcaControllerTest
    {
        private readonly Mock<IMarcaRepository> marcaRepositoryMock = MarcaRepositoryMock.Instancia().Mock();

        [Fact]
        public void Inserir_Sucesso()
        {
            var controller = CreateMarcaController();

            var result = controller.Inserir(ObterObjeto());

            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Inserir_Falha()
        {
            var controller = CreateMarcaController();

            var result = controller.Inserir(new Marca());

            Assert.True(result.IsFaulted);
        }

        private MarcaController CreateMarcaController()
        {
            var marcaService = new MarcaService(marcaRepositoryMock.Object);

            return new MarcaController(marcaService);
        }

        public Marca ObterObjeto()
        {
            return new Marca
            {
                Id = Guid.NewGuid(),
                Descricao = "teste"
            };
        }
    }
}
