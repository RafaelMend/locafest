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
    public class VeiculoControllerTest
    {
        private readonly Mock<IVeiculoRepository> veiculoRepositoryMock = VeiculoRepositoryMock.Instancia().Mock();
        private readonly Mock<IMarcaRepository> marcaRepositoryMock = MarcaRepositoryMock.Instancia().Mock();
        private readonly Mock<IModeloRepository> modeloRepositoryMock = ModeloRepositoryMock.Instancia().Mock();

        [Fact]
        public void Inserir_Sucesso()
        {
            var controller = CreateVeiculoController();

            var result = controller.Inserir(ObterObjeto());

            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Inserir_Falha()
        {
            var controller = CreateVeiculoController();

            var result = controller.Inserir(new Veiculo());

            Assert.True(result.IsFaulted);
        }

        private VeiculoController CreateVeiculoController()
        {
            var veiculoService = new VeiculoService(veiculoRepositoryMock.Object, marcaRepositoryMock.Object, modeloRepositoryMock.Object);

            return new VeiculoController(veiculoService);
        }

        public Veiculo ObterObjeto()
        {
            return new Veiculo
            {
                Id = Guid.NewGuid(),
                Ano = 2015,
                CategoriaId = Guid.NewGuid(),
                LimitePortaMala = 250,
                CombustivelId = Guid.NewGuid(),
                MarcaId = Guid.NewGuid(),
                ModeloId = Guid.NewGuid(),
                Placa = "XFF-0001",
                ValorHora = 30
            };
        }
    }
}
