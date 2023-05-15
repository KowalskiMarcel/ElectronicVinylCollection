using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using ElectronicVinylCollection.Entities;
using ElectronicVinylCollection.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ElectronicVinylCollection.Controllers
{
    [ApiController]
    [Route("api")]
    public class VinylController : ControllerBase
    {
        private readonly VinylDbContext _dbContext;
        private readonly IMapper _mapper;

        public VinylController(VinylDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet("user")]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var users = _dbContext
                .Users
                .ToList();

            var usersDtos = _mapper.Map<List<UserDto>>(users);

            return Ok(usersDtos);
        }

        [HttpGet("user/{id}")]
        public ActionResult<User> Get([FromRoute]int id) 
        {
            var user = _dbContext
                .Users
                .Include(u => u.Medias)
                .FirstOrDefault(u => u.Id == id);

            if(user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost("user")]
        public ActionResult CreateUser([FromBody]CreateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Created($"/api/user/{user.Id}", null);
        }
    }
}
