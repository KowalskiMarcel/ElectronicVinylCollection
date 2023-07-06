using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using ElectronicVinylCollection.Entities;
using ElectronicVinylCollection.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ElectronicVinylCollection.Services;

namespace ElectronicVinylCollection.Controllers
{
    [ApiController]
    [Route("api")]
    public class VinylController : ControllerBase
    {

        private readonly IUserService _userService;

        public VinylController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user")]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            var usersDtos = _userService.GetAll();

            return Ok(usersDtos);
        }

        [HttpGet("user/{id}")]
        public ActionResult<User> Get([FromRoute]int id) 
        {
            var user = _userService.GetById(id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("user")]
        public ActionResult CreateUser([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _userService.Create(dto);

            return Created($"/api/user/{id}", null);
        }

        [HttpDelete("user/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _userService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("user/{id}")]
        public ActionResult Put([FromBody] ModificateUserDto dto, [FromRoute] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdatyd = _userService.Put(id, dto);
            if (!isUpdatyd)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
