using com.locafest.Domain.LocacaoContext.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Interface.Service
{
    public interface ISimulacaoService
    {
        SimulacaoModel ObterSimulacao(Guid veiculoId, DateTime dataRetirada, DateTime dataDevolucao);
    }
}
