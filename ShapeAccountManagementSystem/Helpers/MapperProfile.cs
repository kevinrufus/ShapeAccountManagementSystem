using AutoMapper;
using ShapeAccountManagementSystem.Core.Dtos.Receivables;
using ShapeAccountManagementSystem.Core.Entities;
using ShapeAccountManagementSystem.Models.Receivables;

namespace ShapeAccountManagementSystem.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserReceivableDto, CreateUserReceivableDto>();
            //CreateMap<CreateUserReceivableDto, User>().ForMember(model => model.Password, option => option.Ignore());

        }
    }
}
