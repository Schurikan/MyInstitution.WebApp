using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<TSource, TDestination>();

            CreateMap<User, User>();
            CreateMap<User, Entities.User>().ForMember(dest => dest.PasswordHash, act => act.Ignore())
                                            .ForMember(dest => dest.PasswordSalt, act => act.Ignore());
            CreateMap<RegisterModel, Entities.User>();
            CreateMap<UpdateModel, Entities.User>();
            CreateMap<Entities.User, UserModel>();
        }
    }
}