using FinRust.Application.Common.Interfaces;
using FinRust.Application.Notifications.Models;
using System.Threading.Tasks;

namespace FinRust.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
