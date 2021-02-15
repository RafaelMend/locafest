using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain.Model
{
    public class AutenticacaoModel : Notifiable
    {
        public string Login { get; set; }
        public string Mensagem { get; set; }
        public bool Autenticado { get; set; }
        public int Perfil { get; set; }
        public object ObjetoReferencia { get; set; }
    }
}
