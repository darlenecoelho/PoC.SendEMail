using MediatR;
using PoC.SendEmail.API.Domain.Interfaces;
using PoC.SendEmail.API.Domain.Models;

namespace PoC.SendEmail.API.Application.Commands.CreateSubscriber;

public class CreateSubscriberCommandHandler : IRequestHandler<CreateSubscriberRequest, string>
{
    private readonly ISubscriberRepository _subscriberRepository;
    public CreateSubscriberCommandHandler(ISubscriberRepository subscriberRepository)
    {
        _subscriberRepository = subscriberRepository;

    }
    public async Task<string> Handle(CreateSubscriberRequest request, CancellationToken cancellationToken)
    {
        var subscriber = new Subscriber { Email = request.Email, DateCreated = DateTime.Now };
        int id = await _subscriberRepository.Add(subscriber);

        return request.Email;
    }
}
