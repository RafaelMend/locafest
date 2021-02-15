using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace com.locafest.Domain.Model
{
    public class LoginModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string ConfirmacaoSenha { get; set; }

        public bool SenhaConfere()
        {
            return Senha.Equals(ConfirmacaoSenha);
        }
    }
}
