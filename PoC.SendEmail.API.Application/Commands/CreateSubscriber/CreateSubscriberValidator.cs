using FluentValidation;

namespace PoC.SendEmail.API.Application.Commands.CreateSubscriber;

public class CreateSubscriberValidator : AbstractValidator<CreateSubscriberRequest>
{
    public CreateSubscriberValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
    }
}
