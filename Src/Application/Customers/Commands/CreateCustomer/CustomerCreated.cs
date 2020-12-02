using FinRust.Application.Common.Interfaces;
using FinRust.Application.Notifications.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Customers.Commands.CreateCustomer
{
    public class CustomerCreated : INotification
    {
        public int CustomerId { get; set; }

        public class CustomerCreatedHandler : INotificationHandler<CustomerCreated>
        {
            private readonly INotificationService _notification;

            public CustomerCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new MessageDto());
            }
        }
    }
}
