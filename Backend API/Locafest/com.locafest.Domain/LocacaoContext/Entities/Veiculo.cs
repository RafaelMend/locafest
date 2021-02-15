using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Entities
{
    public class Veiculo : BaseEntity
    {
        public string Placa { get; set; }
        public int Ano { get; set; }
        public decimal ValorHora { get; set; }
        public int LimitePortaMala { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid CombustivelId { get; set; }
        public Guid MarcaId { get; set; }
        public Guid ModeloId { get; set; }

        public Marca Marca { get; set; }
        public Modelo Modelo { get; set; }
    }
}
