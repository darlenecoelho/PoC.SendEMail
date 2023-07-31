using AutoMapper;
using PoC.SendEmail.API.Application.Commands.CreateSubscriber;
using PoC.SendEmail.API.Application.Commands.GetAllSubscriber;
using PoC.SendEmail.API.Domain.Models;

namespace PoC.SendEmail.API.Application.Mappings.SubscriberMapper;

public class SubscriberMappingProfile : Profile
{
    public SubscriberMappingProfile()
    {
        CreateMap<CreateSubscriberRequest, Subscriber>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<Subscriber, GetAllSubscribersResponse>();
    }
}
