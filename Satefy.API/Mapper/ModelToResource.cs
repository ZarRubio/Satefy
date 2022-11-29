using AutoMapper;
using Safety.Infraestructure.Models;
using Satefy.API.Resource;

namespace Satefy.API.Mapper;

public class ModelToResource : Profile
{
   public ModelToResource()
   {
      CreateMap<Guardian, GuardianResource>();
      CreateMap<Urgency, UrgencyResource>();
   }
}