using AutoMapper;
using Domain.Entity;
using Infrastructure.Model.Request.RequestAccount;
using Infrastructure.Model.Response.ResponseAccount;
using Infrastructure.Model.Security;

namespace Infrastructure.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<RequestLogin, Account>()
                .ForMember(p => p.Username, act => act.MapFrom(src => src.UserName))
                .ForMember(p => p.Password, act => act.MapFrom(src => src.Password));


            //------------------------------------------------------------
            CreateMap<RefreshTokenRequest, RefreshToken>()
                 .ForMember(p => p.Token, act => act.MapFrom(src => src.RefreshToken));

            CreateMap<AccessToken, AuthenResponseMessToken>()
                .ForMember(p => p.Token, act => act.MapFrom(src => src.Token))
                .ForMember(p => p.Expiration, act => act.MapFrom(src => src.ExpirationTicks))
                .ForMember(p => p.RefreshToken, act => act.MapFrom(src => src.RefreshToken.Token));

            //----------------------------------------------------------------


            CreateMap<RequestRegisterAccount, Account>()
                 .ForMember(p => p.Username, act => act.MapFrom(src => src.Username))
                 .ForMember(p => p.Password, act => act.MapFrom(src => src.Password))
                 .ForMember(p => p.Phone, act => act.MapFrom(src => src.Phone))
                 .ForMember(p => p.Birthday, act => act.MapFrom(src => src.Birthday))
                 .ForMember(p => p.Address, act => act.MapFrom(src => src.Address))
                 .ForMember(p => p.Email, act => act.MapFrom(src => src.Email));
        }
    }
}
