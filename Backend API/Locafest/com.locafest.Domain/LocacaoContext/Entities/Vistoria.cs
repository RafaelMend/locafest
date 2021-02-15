using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace com.locafest.Domain.LocacaoContext.Entities
{
    public class Vistoria : BaseEntity
    {
        public bool IndiceCarroLimpo { get; set; }
        public bool IndiceTanqueCheio { get; set; }
        public bool IndiceAmassados { get; set; }
        public bool IndiceArranhoes { get; set; }
        public decimal PercentualOcorrencia { get; set; }
        public Guid ContratoId { get; set; }
        [JsonIgnore]
        public Contrato Contrato { get; set; }
    }
}
