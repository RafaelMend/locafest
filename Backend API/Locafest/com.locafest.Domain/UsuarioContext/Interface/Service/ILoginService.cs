using com.locafest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.UsuarioContext.Interface.Service
{
    public interface ILoginService
    {
        AutenticacaoModel LoginNormal(LoginModel login);
    }
}
