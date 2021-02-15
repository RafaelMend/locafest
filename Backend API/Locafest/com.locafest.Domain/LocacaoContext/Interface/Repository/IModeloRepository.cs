using com.locafest.Domain.LocacaoContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Interface
{
    public interface IModeloRepository
    {
        int Inserir(Modelo modelo);
        Modelo Obter(Guid modeloId);
    }
}
