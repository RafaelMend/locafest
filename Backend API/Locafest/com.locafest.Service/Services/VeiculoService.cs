using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IModeloRepository _modeloRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository, IMarcaRepository marcaRepository, IModeloRepository modeloRepository)
        {
            _veiculoRepository = veiculoRepository;
            _marcaRepository = marcaRepository;
            _modeloRepository = modeloRepository;
        }

        public Veiculo Obter(Guid veiculoId)
        {
            var veiculo = _veiculoRepository.Obter(veiculoId);
            veiculo.Marca = _marcaRepository.Obter(veiculo.MarcaId);
            veiculo.Modelo = _modeloRepository.Obter(veiculo.ModeloId);
            return veiculo;
        }

        public Result Inserir(Veiculo veiculo)
        {
            try
            {
                int retorno = _veiculoRepository.Inserir(veiculo);
                if (retorno == 1)
                    return Result.Ok();
                else
                {
                    veiculo.AddNotification("Erros", "Ocorreu algum erro na transação do banco de dados.");
                    return Result.Error(veiculo.Notifications);
                }
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                veiculo.AddNotification("Erros", e.Message);
                return Result.Error(veiculo.Notifications);
            }

        }
    }
}
