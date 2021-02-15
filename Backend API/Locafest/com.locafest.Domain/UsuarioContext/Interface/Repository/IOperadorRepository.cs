using com.locafest.Domain.UsuarioContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.UsuarioContext.Interface.Repository
{
    public interface IOperadorRepository
    {
        int Inserir(Operador operador);
        Operador Obter(string matricula, string senha);
    }
}
