using com.locafest.API.Controllers;
using com.locafest.Domain.LocacaoContext.Entities;
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
    public class ClienteControllerTest
    {
        private readonly Mock<IClienteRepository> clienteRepositoryMock = ClienteRepositoryMock.Instancia().Mock();
        private readonly Mock<IEnderecoRepository> enderecoRepositoryMock = EnderecoRepositoryMock.Instancia().Mock();
        private readonly Mock<IUsuarioRepository> usuarioRepositoryMock = UsuarioRepositoryMock.Instancia().Mock();

        [Fact]
        public void Inserir_Sucesso()
        {
            var controller = CreateClienteController();

            var result = controller.Inserir(ObterObjeto());

            Assert.True(result.IsCompleted);
        }

        [Fact]
        public void Inserir_Falha()
        {
            var controller = CreateClienteController();

            var result = controller.Inserir(new Cliente());

            Assert.True(result.IsFaulted);
        }

        private ClienteController CreateClienteController()
        {
            var clienteService = new ClienteService(usuarioRepositoryMock.Object, 
                enderecoRepositoryMock.Object, clienteRepositoryMock.Object);

            return new ClienteController(clienteService);
        }

        public Cliente ObterObjeto()
        {
            return new Cliente
            {
                Id = Guid.NewGuid(),
                Nome = "Teste",
                Cpf = "32323213213",
                Aniversario = DateTime.Now,
                EnderecoId = Guid.NewGuid(),
                UsuarioId = Guid.NewGuid()
            };
        }
    }
}
