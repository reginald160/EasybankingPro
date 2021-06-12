using Infrastructure.Persistence.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Core.Notification
{
    public class ValueAddedNotification : INotification
    {
        public string Value { get; set; }
    }

    public class EmailHandler : INotificationHandler<ValueAddedNotification>
    {
        private readonly ApplicationDbContext _db;

        public EmailHandler(ApplicationDbContext db)
        {

            _db = db;
        }

        public Task Handle(ValueAddedNotification notification, CancellationToken cancellationToken)
        {
            //_db.EventOccured(notification.Value, "Email sent");
            return Task.CompletedTask;
        }
    }

    public class CacheInvalidationHandler : INotificationHandler<ValueAddedNotification>
    {
        private readonly ApplicationDbContext _db;

        public CacheInvalidationHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task Handle(ValueAddedNotification notification, CancellationToken cancellationToken)
        {
            //_db.EventOccured(notification.Value, "Cache invalidated");
            return Task.CompletedTask;
        }
    }
}
