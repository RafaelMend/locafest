using com.locafest.Domain;
using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using Serilog;
using System;

namespace com.locafest.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IUsuarioRepository usuarioRepository, IEnderecoRepository enderecoRepository, IClienteRepository clienteRepository)
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
            _clienteRepository = clienteRepository;
        }

        public Cliente Obter(Guid clienteId)
        {
            var cliente = _clienteRepository.Obter(clienteId);
            cliente.Endereco = _enderecoRepository.Obter(cliente.EnderecoId);
            return cliente;
        }

        public Result Inserir(Cliente cliente)
        {
            try
            {
                if (cliente.Usuario != null)
                    _usuarioRepository.Inserir(cliente.Usuario);
                if (cliente.Endereco != null)
                    _enderecoRepository.Inserir(cliente.Endereco);
                int retorno = _clienteRepository.Inserir(cliente);
                if (retorno == 1)
                    return Result.Ok();
                else
                {
                    cliente.AddNotification("Erros", "Ocorreu algum erro na transação do banco de dados.");
                    return Result.Error(cliente.Notifications);
                }
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                cliente.AddNotification("Erros", e.Message);
                return Result.Error(cliente.Notifications);
            }
            
        }
    }
}
