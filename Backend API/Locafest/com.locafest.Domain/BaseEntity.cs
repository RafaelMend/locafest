using System;
using Flunt.Notifications;

namespace com.locafest.Domain
{
    public class BaseEntity : Notifiable
    {
        protected BaseEntity(Guid id = default)
        {
            Id = id;
        }

        public virtual Guid Id { get; set; }
    }
}
