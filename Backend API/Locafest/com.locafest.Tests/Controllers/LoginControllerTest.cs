using com.locafest.API.Controllers;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Domain.Model;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Service.Services;
using com.locafest.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace com.locafest.Tests.Controllers
{
    public class LoginControllerTest
    {
        private readonly Mock<IClienteRepository> clienteRepositoryMock = ClienteRepositoryMock.Instancia().Mock();
        private readonly Mock<IOperadorRepository> operadorRepositoryMock = OperadorRepositoryMock.Instancia().Mock();

        [Fact]
        public void Login_Test()
        {
            var controller = CreateLoginController();
            var result = controller.Login(ObterObjeto());

            Assert.IsType<OkObjectResult>(result);
        }

        private LoginController CreateLoginController()
        {
            var loginService = new LoginService(clienteRepositoryMock.Object, 
                operadorRepositoryMock.Object);

            return new LoginController(loginService);
        }

        public LoginModel ObterObjeto()
        {
            return new LoginModel
            {
                Login = "teste",
                Senha = "123456",
                ConfirmacaoSenha = "123456"
            };
        }

        public LoginModel ObterObjetoDiferente()
        {
            return new LoginModel
            {
                Login = "teste",
                Senha = "123456",
                ConfirmacaoSenha = "354442"
            };
        }
    }
}
