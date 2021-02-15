using com.locafest.Domain.LocacaoContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Interface.Service
{
    public interface IVistoriaService
    {
        Vistoria Obter(Guid vistoriaId);
        Result Inserir(Vistoria vistoria);
    }
}
