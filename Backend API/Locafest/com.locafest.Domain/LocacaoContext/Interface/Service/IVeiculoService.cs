using com.locafest.Domain.LocacaoContext.Entities;
using System;

namespace com.locafest.Domain.LocacaoContext.Interface.Service
{
    public interface IVeiculoService
    {
        Result Inserir(Veiculo veiculo);
        Veiculo Obter(Guid veiculoId);
    }
}
