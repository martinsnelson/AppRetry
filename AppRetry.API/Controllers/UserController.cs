using System.Collections.Generic;
using System.Threading.Tasks;
using AppRetry.API.DTO;
using AppRetry.API.Entities;
using AppRetry.API.Infra.Interface;
using AppRetry.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppRetry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iUserRepository;
        private readonly IMapper _imapper;
        public UserController(IUserRepository userRepository, IMapper iMapper)
        {
            _iUserRepository = userRepository;
            _imapper = iMapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> ObterUsers()
        {
            var data = await _iUserRepository.ObterUsers();
            return Ok(data);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> SaveUser([FromBody] UserDTO userDTO)
        {
            userDTO.Email = userDTO.Email.ToLower();
            if (await _iUserRepository.UserExists(userDTO.Email))
                return BadRequest("Email já existe");

            var createUser = _imapper.Map<User>(userDTO);
            var createdUser = await _iUserRepository.SaveUser(createUser);

            return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _iUserRepository.GetUser(id);
            if (user.Equals(null))
                return NotFound();

            return user;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> AlterUser(long id, [FromBody] User user)
        {
            if (id != user.UserId)
                return BadRequest();

            await _iUserRepository.AlterUser(user);
            
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> SmallChangeUser(long id, [FromBody] User user)
        {
            if (id != user.UserId)
                return BadRequest();

            await _iUserRepository.AlterUser(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            var user = await _iUserRepository.GetUser(id);

            if (user.Equals(null))
                return NotFound();

            await _iUserRepository.DeleteUser(id);

            return NoContent();
        }
    }
}