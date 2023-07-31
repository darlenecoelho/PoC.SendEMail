using AutoMapper;
using MediatR;
using PoC.SendEmail.API.Domain.Interfaces;

namespace PoC.SendEmail.API.Application.Commands.GetAllSubscriber;

public class GetAllSubscribersQueryHandler : IRequestHandler<GetAllSubscribersRequest, List<GetAllSubscribersResponse>>
{
    private readonly ISubscriberRepository _subscriberRepository;
    private readonly IMapper _mapper;
    public GetAllSubscribersQueryHandler(ISubscriberRepository subscriberRepository, IMapper mapper)
    {
        _subscriberRepository = subscriberRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllSubscribersResponse>> Handle(GetAllSubscribersRequest request, CancellationToken cancellationToken)
    {
        var subscribers = await _subscriberRepository.GetAllSubscribers();
        var response = _mapper.Map<List<GetAllSubscribersResponse>>(subscribers);
        return response;
    }
}
