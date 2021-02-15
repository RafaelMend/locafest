using com.locafest.Domain.LocacaoContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Interface
{
    public interface IVeiculoRepository
    {
        int Inserir(Veiculo veiculo);
        Veiculo Obter(Guid veiculoId);
    }
}
