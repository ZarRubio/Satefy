using AutoMapper;
using Safety.Infraestructure.Models;
using Satefy.API.Resource;

namespace Satefy.API.Mapper;

public class ResourceToModel : Profile
{
    public ResourceToModel()
    {
        CreateMap<GuardianResource, Guardian>();
        CreateMap<UrgencyResource, Urgency>();  
    }

}