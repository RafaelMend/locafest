using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Model
{
    public class ContratoPdfModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string ModeloVeiculo { get; set; }
        public string MarcaVeiculo { get; set; }
        public int AnoVeiculo { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataDevolucao { get; set; }
        public decimal ValorFinal { get; set; }
        public decimal QuantidadeHoras { get; set; }
    }
}
