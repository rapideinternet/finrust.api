using FinRust.Application.Notifications.Models;
using System.Threading.Tasks;

namespace FinRust.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
