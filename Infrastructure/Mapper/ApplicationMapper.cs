using AutoMapper;
using Domain.Entity;
using Infrastructure.Model.Request.RequestAccount;
using Infrastructure.Model.Request.RequestResource;
using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseAccount;
using Infrastructure.Model.Response.ResponseResource;
using Infrastructure.Model.Response.ResponseTask;
using Infrastructure.Model.Security;

namespace Infrastructure.Mapper;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {

        //----------------------------------------------------------------
        // Login
        //----------------------------------------------------------------
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
        //Account
        //----------------------------------------------------------------

        CreateMap<RequestRegisterAccount, Account>()
             .ForMember(p => p.Username, act => act.MapFrom(src => src.Username))
             .ForMember(p => p.Password, act => act.MapFrom(src => src.Password))
             .ForMember(p => p.Phone, act => act.MapFrom(src => src.Phone))
             .ForMember(p => p.Birthday, act => act.MapFrom(src => src.Birthday))
             .ForMember(p => p.Address, act => act.MapFrom(src => src.Address))
             .ForMember(p => p.Email, act => act.MapFrom(src => src.Email));


        CreateMap<Account, ResponseAllAccount>()
           .ForMember(p => p.Username, act => act.MapFrom(src => src.Username))
           .ForMember(p => p.Password, act => act.MapFrom(src => src.Password))
           .ForMember(p => p.Role, act => act.MapFrom(src => src.Role));
        //.ForMember(p => p.Feed, act => act.MapFrom(src => src.Feedbacks))
        //.ForMember(p => p.TaskCreators, act => act.MapFrom(src => src.TaskCreators))
        //.ForMember(p => p.TaskEmployees, act => act.MapFrom(src => src.TaskEmployees));


        // UpdateAccount
        CreateMap<UpdateAccount, Account>()
             .ForMember(p => p.Password, act => act.MapFrom(src => src.Password))
             .ForMember(p => p.Phone, act => act.MapFrom(src => src.Phone))
             .ForMember(p => p.Birthday, act => act.MapFrom(src => src.Birthday))
             .ForMember(p => p.Address, act => act.MapFrom(src => src.Address))
             .ForMember(p => p.Email, act => act.MapFrom(src => src.Email));


        //----------------------------------------------------------------
        //Task
        //----------------------------------------------------------------

        // RequestTask
        CreateMap<RequestTaskResource, Job>()
             .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
             .ForMember(p => p.NameTask, act => act.MapFrom(src => src.NameTask))
             .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
             .ForMember(p => p.CreatorId, act => act.MapFrom(src => src.CreatorId))
             .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId))
             .ForMember(p => p.Description, act => act.MapFrom(src => src.DescriptionJob))
             .ForMember(c => c.Resources, act => act.MapFrom(c => new List<Resource>
             {
                 new Resource
                 {
                 Size = c.Size,
                 CreatedAt = DateTime.Now,
                 Description = c.Description,
                 Status = "INACTIVE",
                 TotalQuantity = c.TotalQuantity,
                 Image = c.Image,
                 UsedQuantity = 0,
                 NameResource = c.NameResource,
                 }
             }));


        CreateMap<RequestUpdateTask, Job>()
             .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
             .ForMember(p => p.NameTask, act => act.MapFrom(src => src.NameTask))
             .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
             .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
             .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId));


        // ResponseTask
        CreateMap<Job, ResponseTask>()
             .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
             .ForMember(p => p.CreatedAt, act => act.MapFrom(src => src.CreatedAt))
             .ForMember(p => p.NameTask, act => act.MapFrom(src => src.NameTask))
             .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
             .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
             .ForMember(p => p.CreatorId, act => act.MapFrom(src => src.CreatorId))
             .ForMember(p => p.TaskId, act => act.MapFrom(src => src.JobId))
             .ForMember(p => p.emailEmployee, act => act.MapFrom(src => src.Employee.Email))
             .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
             .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId));

        //----------------------------------------------------------------
        // Resource 
        //----------------------------------------------------------------

        // Request Resource

        // Response Resource
        CreateMap<Resource, ResponseResource>()
             .ForMember(p => p.ResourcesId, act => act.MapFrom(src => src.ResourcesId))
             .ForMember(p => p.NameResource, act => act.MapFrom(src => src.NameResource))
             .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
             .ForMember(p => p.UsedQuantity, act => act.MapFrom(src => src.UsedQuantity))
             .ForMember(p => p.TotalQuantity, act => act.MapFrom(src => src.TotalQuantity))
             .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
             .ForMember(p => p.Size, act => act.MapFrom(src => src.Size))
             .ForMember(p => p.CreatedAt, act => act.MapFrom(src => src.CreatedAt))
             .ForMember(p => p.TaskId, act => act.MapFrom(src => src.JobId))
             .ForMember(p => p.Image, act => act.MapFrom(src => src.Image));
    }
}
