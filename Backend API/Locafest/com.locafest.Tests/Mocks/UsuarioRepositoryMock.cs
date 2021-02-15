using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Tests.Base;
using System;

namespace com.locafest.Tests.Mocks
{
    internal class UsuarioRepositoryMock : MockBase<IUsuarioRepository, UsuarioRepositoryMock>
    {
        public UsuarioRepositoryMock Inserir(Usuario usuario)
        {
            mock.Setup(mock => mock.Inserir(usuario));
            return this;
        }
    }
}
