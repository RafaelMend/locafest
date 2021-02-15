using com.locafest.Domain.UsuarioContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.UsuarioContext.Interface.Repository
{
    public interface IUsuarioRepository
    {
        int Inserir(Usuario usuario);
    }
}
