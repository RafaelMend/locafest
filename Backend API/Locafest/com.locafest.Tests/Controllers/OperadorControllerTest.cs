using com.locafest.API.Controllers;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Service.Services;
using com.locafest.Tests.Mocks;
using Moq;
using System;
using Xunit;

namespace com.locafest.Tests.Controllers
{
    public class OperadorControllerTest
    {
        private readonly Mock<IOperadorRepository> operadorRepositoryMock = OperadorRepositoryMock.Instancia().Mock();
        private readonly Mock<IUsuarioRepository> usuarioRepositoryMock = UsuarioRepositoryMock.Instancia().Mock();

        [Fact]
        public void Inserir_Sucesso()
        {
            var controller = CreateOperadorController();

            var result = controller.Inserir(ObterObjeto());

            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Inserir_Falha()
        {
            var controller = CreateOperadorController();

            var result = controller.Inserir(new Operador());

            Assert.True(result.IsFaulted);
        }

        private OperadorController CreateOperadorController()
        {
            var operadorService = new OperadorService(usuarioRepositoryMock.Object, operadorRepositoryMock.Object);

            return new OperadorController(operadorService);
        }

        public Operador ObterObjeto()
        {
            return new Operador
            {
                Id = Guid.NewGuid(),
                Matricula = "12345",
                Nome = "teste",
                UsuarioId = Guid.NewGuid()
            };
        }
    }
}
