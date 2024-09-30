using AutoMapper;
using jjournal.Communication.Requests.User;
using jjournal.Domain.Models.Entities;

namespace jjournal.Application.Services.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RegisterUserRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
