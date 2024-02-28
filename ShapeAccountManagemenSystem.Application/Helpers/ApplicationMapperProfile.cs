using AutoMapper;
using ShapeAccountManagementSystem.Core.Dtos.Receivables;
using ShapeAccountManagementSystem.Core.Entities;

namespace ShapeAccountManagemenSystem.Application.Helpers
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<CreateUserReceivableDto, User>().ForMember(model => model.PasswordHash, option => option.Ignore());
        }
    }
}
