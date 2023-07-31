using MediatR;

namespace PoC.SendEmail.API.Application.Commands.GetAllSubscriber;

public class GetAllSubscribersRequest : IRequest<List<GetAllSubscribersResponse>> { }
