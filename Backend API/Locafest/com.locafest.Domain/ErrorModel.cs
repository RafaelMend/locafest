using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Domain
{
    public class ErrorModel
    {
        /// <summary>
        /// Lista de mensagens de erro
        /// </summary>
        public List<string> Erros { get; } = new List<string>();

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="erro"></param>
        public ErrorModel(string erro)
        {
            Erros.Add(erro);
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="erros"></param>
        public ErrorModel(IEnumerable<string> erros)
        {
            Erros.AddRange(erros);
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="notifications"></param>
        public ErrorModel(IReadOnlyCollection<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                Erros.Add(notification.Message);
            }
        }
    }
}
