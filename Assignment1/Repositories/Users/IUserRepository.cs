using Assignment1.DataContextModels;
using Assignment1.DTOs;

namespace Assignment1.Repositories.Users
{
    public interface IUserRepository
    {
        Task<UserDto> Create(UserDto user);
        Task<UserDto> Delete(int id);
        Task<IEnumerable<User>> Get();
        Task<User> GetById(int id);
        Task<UserDto> Update(int id, UserDto user);
    }
}