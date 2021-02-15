using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Entities
{
    public class Contrato : BaseEntity
    {
        public DateTime DataContratacao { get; set; }
        public Guid AgendamentoId { get; set; }
        public Agendamento Agendamento { get; set; }
    }
}
