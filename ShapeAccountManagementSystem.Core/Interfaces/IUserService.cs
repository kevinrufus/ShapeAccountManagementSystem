using ShapeAccountManagementSystem.Core.Dtos.Receivables;

namespace ShapeAccountManagementSystem.Core.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateUser(CreateUserReceivableDto user);
        public Task<bool> Login(string name, string password);

    }
}
