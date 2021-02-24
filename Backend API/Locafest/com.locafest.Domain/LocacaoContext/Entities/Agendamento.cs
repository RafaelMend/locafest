using com.locafest.Domain.UsuarioContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace com.locafest.Domain.LocacaoContext.Entities
{
    public class Agendamento : BaseEntity
    {
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public string Local { get; set; }
        public decimal ValorHora { get; set; }
        public decimal QuantidadeHoras { get; set; }
        public decimal ValorFinal { get; set; }
        public Guid VeiculoId { get; set; }
        public Guid ClienteId { get; set; }
        [JsonIgnore]
        public Veiculo Veiculo { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
