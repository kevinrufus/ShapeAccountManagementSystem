using AutoMapper;
using ShapeAccountManagemenSystem.Application.Helpers;
using ShapeAccountManagementSystem.Core.Dtos.Receivables;
using ShapeAccountManagementSystem.Core.Entities;
using ShapeAccountManagementSystem.Core.Interfaces;

namespace ShapeAccountManagemenSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> CreateUser(CreateUserReceivableDto userInput)
        {
            #region Check If email already registered or not
            var isEmailExist = _repository.Find(user => user.Email.Equals(userInput.Email)).Any();
            if (isEmailExist)
                return false;
            #endregion

            #region Insert New User To Database
            var newUser = _mapper.Map<User>(userInput);
            newUser.Salt = PasswordHashHelper.CreateSalt();
            newUser.PasswordHash = await PasswordHashHelper.Hash(userInput.Password, newUser.Salt);
            await _repository.Add(newUser);
            return true;
            #endregion
        }

        public async Task<bool> Login(string name, string password)
        {
            var user = _repository.Find(user => user.FirstName == name).FirstOrDefault();
            if (user != null)
                return await PasswordHashHelper.VerifyPassword(password, Convert.ToBase64String(user?.Salt!), Convert.ToBase64String(user?.PasswordHash!));
            else 
                return false;
        }
    }
}
