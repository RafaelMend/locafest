using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Model
{
    public class SimulacaoModel
    {
        public SimulacaoModel(Guid veiculoId, DateTime dataRetirada, DateTime dataDevolucao, decimal valorHora)
        {
            VeiculoId = veiculoId;
            DataRetirada = dataRetirada;
            DataDevolucao = dataDevolucao;
            ValorHora = valorHora;
        }

        public Guid VeiculoId { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public decimal ValorHora { get; set; }
        public decimal QuantidadeHoras { get { return _QuantidadeHoras(); } }
        public decimal ValorTotal { get { return _ValorTotal(); } }

        private decimal _QuantidadeHoras()
        {
            return (decimal) (DataDevolucao - DataRetirada).TotalHours;
        }

        private decimal _ValorTotal()
        {
            var quantidadeHoras = (decimal)(DataDevolucao - DataRetirada).TotalHours;
            return quantidadeHoras * ValorHora;
        }
    }
}
