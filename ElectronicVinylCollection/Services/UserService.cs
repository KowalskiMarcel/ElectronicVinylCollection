using AutoMapper;
using ElectronicVinylCollection.Entities;
using ElectronicVinylCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicVinylCollection.Services
{
    public interface IUserService
    {
        UserDto GetById(int id);
        IEnumerable<UserDto> GetAll();
        int Create(CreateUserDto dto);
        bool Delete(int id);
        bool Put(int id, ModificateUserDto user);
    }
    public class UserService : IUserService
    {
        private readonly VinylDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(VinylDbContext dbContext, IMapper mapper, ILogger<UserService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public UserDto GetById(int id)
        {
            var user = _dbContext
                .Users
                .Include(u => u.Medias)
                .FirstOrDefault(u => u.Id == id);

            if(user == null)
            {
                return null;
            }

            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public IEnumerable<UserDto> GetAll()
        {
            
            var users = _dbContext
               .Users
               .ToList();

            var usersDtos = _mapper.Map<List<UserDto>>(users);
            return usersDtos;
        }

        public int Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public int Create(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            _logger.LogWarning($"User with id: {id} DELETE astion invoked");
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user is null) return false;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Put(int id, ModificateUserDto dto)
        {
            var user = _dbContext
                .Users
                .FirstOrDefault(u => u.Id == id);

            if (user is null) return false;

            user.NickName = dto.NickName;
            user.Email = dto.Email;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
