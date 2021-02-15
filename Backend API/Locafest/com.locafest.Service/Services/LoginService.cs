using com.locafest.Domain;
using com.locafest.Domain.Model;
using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using Serilog;
using System;
using System.Collections.Generic;

namespace com.locafest.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IOperadorRepository _operadorRepository;  

        public LoginService(IClienteRepository clienteRepository, IOperadorRepository operadorRepository)
        {
            _clienteRepository = clienteRepository;
            _operadorRepository = operadorRepository;
        }

        public AutenticacaoModel LoginNormal(LoginModel login)
        {
            try
            {
                if (login.SenhaConfere())
                {
                    AutenticacaoModel autenticacao = new AutenticacaoModel();
                    
                    ConfereOperador(login, autenticacao);
                    ConfereCliente(login, autenticacao);

                    if (autenticacao.Login == null)
                        autenticacao = LoginInvalido(login);

                    return autenticacao;
                }
                else
                {
                    return LoginInvalido(login);
                }
            } catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                return new AutenticacaoModel
                {
                    Login = login.Login,
                    Autenticado = false,
                    Mensagem = e.Message
                };
            }
        }

        private static AutenticacaoModel LoginInvalido(LoginModel login)
        {
            return new AutenticacaoModel
            {
                Login = login.Login,
                Autenticado = false,
                Mensagem = "Erro na validação do usuário."
            };
        }

        private void ConfereOperador(LoginModel login, AutenticacaoModel autenticacao)
        {
            Operador operador = _operadorRepository.Obter(login.Login, login.Senha);
            if (operador != null)
            {
                autenticacao.Login = operador.Matricula;
                autenticacao.Perfil = operador.PerfilId;
                autenticacao.Autenticado = true;
                autenticacao.Mensagem = "Login realizado com sucesso.";
                autenticacao.ObjetoReferencia = operador;
            } 
        }

        private void ConfereCliente(LoginModel login, AutenticacaoModel autenticacao)
        {
            Cliente cliente = _clienteRepository.Obter(login.Login, login.Senha);
            if (cliente != null)
            {
                autenticacao.Login = cliente.Cpf;
                autenticacao.Perfil = cliente.PerfilId;
                autenticacao.Autenticado = true;
                autenticacao.Mensagem = "Login realizado com sucesso.";
                autenticacao.ObjetoReferencia = cliente;
            }
        }
    }
}
