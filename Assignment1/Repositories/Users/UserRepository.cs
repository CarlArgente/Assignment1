using Assignment1.DataContext;
using Assignment1.DataContextModels;
using Assignment1.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly SampleDBContext _dbContext;

        public UserRepository(IMapper mapper, SampleDBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        #region
        public async Task<IEnumerable<User>> Get() => await _dbContext.Users.ToListAsync();
        public async Task<User> GetById(int id) => await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        #endregion
        public async Task<UserDto> Create(UserDto user)
        {
            User? model = _mapper.Map<User>(user);
            if (model == null)
                throw new Exception("User is Invalid");

            _dbContext.Users.Add(model);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<UserDto> Update(int id, UserDto user)
        {
            User? model = _mapper.Map<User>(user);
            if (model == null)
                throw new Exception("User is Invalid");

            model.Id = id;

            _dbContext.Users.Update(model);

            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<UserDto> Delete(int id)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(m => m.Id == id);
            User? model = _mapper.Map<User>(user);

            _dbContext.Users.Remove(model);

            await _dbContext.SaveChangesAsync();

            return new UserDto();
        }
    }
}
