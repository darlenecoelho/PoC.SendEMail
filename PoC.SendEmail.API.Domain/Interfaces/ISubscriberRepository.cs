using PoC.SendEmail.API.Domain.Models;

namespace PoC.SendEmail.API.Domain.Interfaces;
public interface ISubscriberRepository
{
    Task<int> Add(Subscriber subscriber);
    Task<bool> GetByEmail(string email);
    Task<IEnumerable<Subscriber>> GetAllSubscribers();
}
