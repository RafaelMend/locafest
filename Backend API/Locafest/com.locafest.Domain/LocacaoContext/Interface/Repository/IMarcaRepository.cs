using com.locafest.Domain.LocacaoContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.LocacaoContext.Interface
{
    public interface IMarcaRepository
    {
        int Inserir(Marca marca);
        Marca Obter(Guid marcaId);
    }
}
