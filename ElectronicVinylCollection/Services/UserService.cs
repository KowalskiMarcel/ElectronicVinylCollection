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
        int Create(UserDto dto);
    }
    public class UserService : IUserService
    {
        private readonly VinylDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(VinylDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
    }
}
