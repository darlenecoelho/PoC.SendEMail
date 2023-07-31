using MediatR;

namespace PoC.SendEmail.API.Application.Commands.CreateSubscriber;

public class CreateSubscriberRequest : IRequest<string>
{
    public string? Email { get; set; }
}
