using AutoMapper;
using Domain.Entity;
using Domain.Enum;
using Infrastructure.Model.Request;
using Infrastructure.Model.Request.RequestAccount;
using Infrastructure.Model.Request.RequestFeedBack;
using Infrastructure.Model.Request.RequestTask;
using Infrastructure.Model.Response.ResponseAccount;
using Infrastructure.Model.Response.ResponseEquipment;
using Infrastructure.Model.Response.ResponseFeedBack;
using Infrastructure.Model.Response.ResponseResource;
using Infrastructure.Model.Response.ResponseTask;
using Infrastructure.Model.Security;

namespace Infrastructure.Mapper;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        // Tạo đối tượng TimeZoneInfo cho múi giờ của Việt Nam
        TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        // Lấy thời gian hiện tại ở Việt Nam
        DateTime vietnamNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);
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

        // RequestTaskResource
        CreateMap<RequestTaskResource, Job>()
             .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
             .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
             .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId))
             .ForMember(p => p.Description, act => act.MapFrom(src => src.DescriptionJob))
             .ForMember(c => c.Resource, act => act.MapFrom(c =>
                 new Resource
                 {
                     Size = c.Size,
                     CreatedAt = vietnamNow,
                     Description = c.Description,
                     Status = StatusResource.INACTIVE.ToString(),
                     TotalQuantity = c.TotalQuantity,
                     Image = c.Image,
                     UsedQuantity = 0,
                     NameResource = c.NameResource,
                 }));

        // RequestTaskResourceRz
        CreateMap<RequestTaskResourceRz, Job>()
            .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
            .ForMember(p => p.CreatorId, act => act.MapFrom(src => src.CreatorId))
            .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
            .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.DescriptionJob))
            .ForMember(c => c.Resource, act => act.MapFrom(c =>
                new Resource
                {
                    Size = c.Size,
                    CreatedAt = DateTime.Now,
                    Description = c.Description,
                    Status = StatusResource.INACTIVE.ToString(),
                    TotalQuantity = c.TotalQuantity,
                    Image = c.Image,
                    UsedQuantity = 0,
                    NameResource = c.NameResource,

                }));


        // RequestTaskEquipment
        CreateMap<RequestTaskEquipment, Job>()
             .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
             .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
             .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId))
             .ForMember(p => p.Description, act => act.MapFrom(src => src.DescriptionJob))
             .ForMember(c => c.HistoryEquipments, act => act.MapFrom(c =>
                 new HistoryEquipment
                 {
                     Date = vietnamNow,
                     NameHistory = NAMETASK.CREATEEQUIPMENT.ToString(),
                     Status = STATUSEQUIPMENT.INACTIVE.ToString(),
                     Equipment = new Equipment
                     {
                         Status = STATUSEQUIPMENT.INACTIVE.ToString(),
                         ImageEquip = c.ImageEquip,
                         Location = c.Location,
                         ResourcesId = c.ResourceId,
                         CreatedAt = vietnamNow,
                     }
                 }));

        // RequestTaskEquipmentRZ
        CreateMap<RequestTaskEquipmentRZ, Job>()
             .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
             .ForMember(p => p.CreatorId, act => act.MapFrom(src => src.CreatorId))
             .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
             .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId))
             .ForMember(p => p.Description, act => act.MapFrom(src => src.DescriptionJob))
             .ForMember(c => c.HistoryEquipments, act => act.MapFrom(c =>
                 new HistoryEquipment
                 {
                     Date = vietnamNow,
                     NameHistory = NAMETASK.CREATEEQUIPMENT.ToString(),
                     Status = STATUSEQUIPMENT.INACTIVE.ToString(),
                     Equipment = new Equipment
                     {
                         Status = STATUSEQUIPMENT.INACTIVE.ToString(),
                         ImageEquip = c.ImageEquip,
                         Location = c.Location,
                         ResourcesId = c.ResourceId,
                         CreatedAt = vietnamNow,

                     }
                 }));

        //---------------------------------------------------------
        // UPDATE TASK EQUIPMENT
        CreateMap<RequestUpdateStatusHistory, Job>()
            .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
            .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
            .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.DescriptionJob))
            .ForMember(c => c.HistoryEquipments, act => act.MapFrom(c =>
                new HistoryEquipment
                {
                    Date = vietnamNow,
                    NameHistory = NAMETASK.FIXEQUIPMENT.ToString(),
                    Status = STATUSEQUIPMENT.INACTIVE.ToString(),
                }));

        // UPDATE TASK EQUIPMENTRZ
        CreateMap<RequestUpdateStatusHistoryRZ, Job>()
            .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
            .ForMember(p => p.CreatorId, act => act.MapFrom(src => src.CreatorId))
            .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline))
            .ForMember(p => p.EmployeeId, act => act.MapFrom(src => src.EmployeeId))
            .ForMember(p => p.Description, act => act.MapFrom(src => src.DescriptionJob))
            .ForMember(c => c.HistoryEquipments, act => act.MapFrom(c =>
                new HistoryEquipment
                {
                    Date = vietnamNow,
                    NameHistory = NAMETASK.FIXEQUIPMENT.ToString(),
                    Status = STATUSEQUIPMENT.INACTIVE.ToString(),
                }));

        //--------------------------------------------------------
        CreateMap<RequestUpdateTask, Job>()
             .ForMember(p => p.Title, act => act.MapFrom(src => src.Title))
             .ForMember(p => p.Description, act => act.MapFrom(src => src.Description))
             .ForMember(p => p.Deadline, act => act.MapFrom(src => src.Deadline));


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




        //----------------------------------------------------------------
        // FeedBack 
        //----------------------------------------------------------------

        CreateMap<RequestFeedBack, Feedback>()
             .ForMember(p => p.Comment, act => act.MapFrom(src => src.Comment))
             .ForMember(p => p.EquipmentId, act => act.MapFrom(src => src.EquipmentId));

        //----------------------------------------------------------------
        CreateMap<Feedback, ResponseFeedBack>()
             .ForMember(p => p.Comment, act => act.MapFrom(src => src.Comment))
             .ForMember(p => p.CreatedAt, act => act.MapFrom(src => src.CreatedAt))
             .ForMember(p => p.FeedBackId, act => act.MapFrom(src => src.FeedBackId))
             .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
             .ForMember(p => p.NumberFeedBack, act => act.MapFrom(src => src.NumberFeedBack))
             .ForMember(p => p.AccountId, act => act.MapFrom(src => src.AccountId))
             .ForMember(p => p.EquipmentId, act => act.MapFrom(src => src.EquipmentId));
        //----------------------------------------------------------------


        //----------------------------------------------------------------
        CreateMap<Equipment, ResponseEquipment>()
             .ForMember(p => p.EquipmentId, act => act.MapFrom(src => src.EquipmentId))
             .ForMember(p => p.ResourcesId, act => act.MapFrom(src => src.ResourcesId))
             .ForMember(p => p.Status, act => act.MapFrom(src => src.Status))
             .ForMember(p => p.Location, act => act.MapFrom(src => src.Location))
             .ForMember(p => p.ImageEquip, act => act.MapFrom(src => src.ImageEquip))
             .ForMember(p => p.CreatedAt, act => act.MapFrom(src => src.CreatedAt));
        //----------------------------------------------------------------
    }
}
